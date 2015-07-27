using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Strategies;
using Mu.Core.Common.Validation;

namespace Mu.Client.Infrastructure.Components.Managers
{
    public class ManagerBase : IManager
    {
        private readonly IComponentStrategy _componentStrategy;
        private readonly IList<IManager> _children;
        private readonly IManager _parent;
        private readonly IDictionary<Type, IController> _controllers;

        protected ManagerBase(
            IManager pParent = null,
            IComponentStrategy pComponentStrategy = null)
        {
            _parent = (pParent ?? NotSetManager.INSTANCE);
            _children = new List<IManager>();
            _componentStrategy = (pComponentStrategy ?? new NoMatchPropagationStrategy(this));
            _controllers = new ConcurrentDictionary<Type, IController>();

            Initialize();
        }

        public virtual IActionResult Execute(object pSouce, IAction pAction)
        {
            if (!CanExecute(pAction))
            {
                return GetCannotExecuteActionResult(pAction);
            }

            return _componentStrategy.Execute(pAction);
        }

        public bool HasChildren()
        {
            return GetChildren().Any();
        }

        public IEnumerable<IManager> GetChildren()
        {
            return _children;
        }

        public IManager GetParent()
        {
            return _parent;
        }

        public virtual void Update(object pState)
        {
            // used by subclasses for state update 
        }

        public void AddManager(IManager pManager)
        {
            if (_children.Contains(pManager))
            {
                return;
            }

            _children.Add(pManager);
        }

        public bool RemoveManager(IManager pManager)
        {
            return _children.Remove(pManager);
        }

        public void SetController(IController pController)
        {
            ArgumentsValidation.NotNull(pController, "pController");

            if (_controllers.ContainsKey(pController.GetType()))
            {
                return;
            }

            _controllers.Add(pController.GetType(), pController);
        }

        public IController GetController(Type pControllerType)
        {
            return GetControllerChecked(pControllerType);
        }

        public TController GetController<TController>() where TController : IController
        {
            return (TController)GetController(typeof(TController));
        }

        public IEnumerable<IController> GetControllers()
        {
            return new ReadOnlyCollection<IController>(_controllers.Values.ToArray());
        }

        protected IActionResult ExecuteToChildren(IAction pAction)
        {
            var childrenResults = ManagerUtilities.ExecuteToChildren(this, pAction) ?? new IActionResult[0];
            return new CompositeActionResult(childrenResults.ToArray());
        }

        protected IController GetControllerChecked(Type pControllerType)
        {
            var controller = InternalGetController(pControllerType);
            if (controller == null)
            {
                throw new InvalidOperationException(string.Format("Missing Controller: {0}", pControllerType.FullName));
            }

            return controller;
        }

        protected IController InternalGetController(Type pControllerType)
        {
            ArgumentsValidation.NotNull(pControllerType, "pControllerType");

            IController controller;
            if (_controllers.TryGetValue(pControllerType, out controller))
            {
                return controller;
            }

            var key = _controllers.Keys.FirstOrDefault(x => x.GetInterface(pControllerType.Name) != null);
            if (key != null)
            {
                return _controllers[key];
            }

            return null;
        }

        protected bool IsActionSource(IAction pAction)
        {
            ArgumentsValidation.NotNull(pAction, "pAction");

            return pAction != null && ReferenceEquals(pAction.GetSource(), this);
        }

        protected virtual bool CanExecute(IAction pAction)
        {
            return !IsActionSource(pAction);
        }

        protected virtual IActionResult GetCannotExecuteActionResult(IAction pAction)
        {
            return new NotAvailableActionResult();
        }

        private void Initialize()
        {
            GetParent().AddManager(this);
        }
    }
}
