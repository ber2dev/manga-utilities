using System.Collections.Generic;
using System.Windows.Controls;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Strategies;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    /// <summary>
    /// Base class for a TabItem user control.
    /// For Design purpose it mantains both parameter-less constructor and full constructor
    /// </summary>
    public class TabItemBase: TabItem, IComponent
    {
        private readonly IComponentStrategy _componentStrategy;
        private readonly IList<IComponent> _children;
        private readonly IComponent _parent;

        protected TabItemBase(
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

        protected bool IsActionSource(IAction pAction)
        {
            return pAction != null && ReferenceEquals(pAction.GetSource(), this);
        }

        private void Initialize()
        {
            GetParent().AddComponent(this);
        }
    }
}
