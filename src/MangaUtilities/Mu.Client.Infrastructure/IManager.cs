using System.Collections.Generic;

namespace Mu.Client.Infrastructure
{
    public interface IManager
    {
        IActionResult Execute(IAction pAction);
        IEnumerable<IController> GetControllers();
    }
}
