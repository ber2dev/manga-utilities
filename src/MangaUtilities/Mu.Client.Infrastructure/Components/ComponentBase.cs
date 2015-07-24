﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Strategies;
using Mu.Core.Common.Validation;

namespace Mu.Client.Infrastructure.Components
{
    public class ComponentBase : IComponent
    {
        private readonly IComponentStrategy _componentStrategy;
        private readonly IList<IComponent> _children;
        private readonly IComponent _parent;

        protected ComponentBase(
            IComponent pParent = null,
            IComponentStrategy pComponentStrategy = null)
        {
            _parent = (pParent ?? NotSetComponent.INSTANCE);
            _children = new List<IComponent>();
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

        public IEnumerable<IComponent> GetChildren()
        {
            return _children;
        }

        public IComponent GetParent()
        {
            return _parent;
        }

        public virtual void Update(object pState)
        {
            // used by subclasses for state update 
        }

        public void AddComponent(IComponent pComponent)
        {
            if (_children.Contains(pComponent))
            {
                return;
            }

            _children.Add(pComponent);
        }

        public bool RemoveComponent(IComponent pComponent)
        {
            return _children.Remove(pComponent);
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
            GetParent().AddComponent(this);
        }
    }
}
