using System.Collections.Generic;

namespace Mu.Client.Infrastructure
{
    public class ComponentBase : IComponent
    {
        private readonly IList<IComponent> _children;
        private readonly IComponent _parent;

        protected ComponentBase(IComponent pParent = null)
        {
            _parent = (pParent ?? NotSetComponent.INSTANCE);
            _children = new List<IComponent>();

            Initialize();
        }

        public virtual IActionResult Execute(IAction pAction)
        {
            return GetParent().Execute(pAction);
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

        private void Initialize()
        {
            GetParent().AddComponent(this);
        }
    }
}
