using System.Collections.Generic;

namespace Mu.Client.Infrastructure
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
