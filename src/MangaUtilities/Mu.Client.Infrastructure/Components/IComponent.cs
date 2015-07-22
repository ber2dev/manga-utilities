using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components
{
    public interface IComponent
    {
        IActionResult Execute(IAction pAction);
        IEnumerable<IComponent> GetChildren();
        IComponent GetParent();

        void Update(object pState);
        void AddComponent(IComponent pComponent);
        bool RemoveComponent(IComponent pComponent);
    }
}
