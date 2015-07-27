using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components.Strategies
{
    public interface IComponentStrategy
    {
        IActionResult Execute(IAction pAction);
    }
}
