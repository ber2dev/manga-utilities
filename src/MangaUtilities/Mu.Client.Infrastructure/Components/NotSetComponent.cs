using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components
{
    public sealed class NotSetComponent : IComponent
    {
        public static readonly IComponent INSTANCE = new NotSetComponent();

        private NotSetComponent()
        {
        }

        public IActionResult Execute(IAction pAction)
        {
            return new NotAvailableActionResult();
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return new IComponent[0];
        }

        public IComponent GetParent()
        {
            return INSTANCE;
        }

        public void Update(object pState)
        {
        }

        public void AddComponent(IComponent pComponent)
        {
            
        }

        public bool RemoveComponent(IComponent pComponent)
        {
            return false;
        }
    }
}
