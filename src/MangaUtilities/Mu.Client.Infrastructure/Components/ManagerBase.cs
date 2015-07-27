using System;
using System.Collections.Generic;
using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Strategies;
using Mu.Core.Common.Validation;

namespace Mu.Client.Infrastructure.Components
{
    public class ManagerBase : IManager
    {
        private readonly IComponentStrategy _componentStrategy;
        private readonly IList<IManager> _children;
        private readonly IManager _parent;

        protected ManagerBase(
            IManager pParent = null,
            IComponentStrategy pComponentStrategy = null)
        {
            _parent = (pParent ?? NotSetManager.INSTANCE);
            _children = new List<IManager>();
            _componentStrategy = (pComponentStrategy ?? new NoMatchPropagationStrategy(this));

            Initialize();
        }

        public virtual IActionResult Execute(IAction pAction)
        {
            if (IsActionSource(pAction))
            {
                return new NotAvailableActionResult();
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
            if (pController.IsManager(this))
            {
                return;
            }

            pController.SetManager(this);
        }

        public IController GetController(Type pControllerType)
        {
            throw new NotImplementedException();
        }

        public TController GetController<TController>() where TController : IController
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IController> GetControllers()
        {
            throw new NotImplementedException();
        }

        protected IActionResult ExecuteToChildren(IAction pAction)
        {
            var childrenResults = ComponentUtilities.ExecuteToChildren(this, pAction) ?? new IActionResult[0];
            return new CompositeActionResult(childrenResults.ToArray());
        }

        protected bool IsActionSource(IAction pAction)
        {
            ArgumentsValidation.NotNull(pAction, "pAction");

            return pAction != null && ReferenceEquals(pAction.GetSource(), this);
        }

        private void Initialize()
        {
            GetParent().AddManager(this);
        }
    }
}
