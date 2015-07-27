using System;
using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.Client.Infrastructure.Components.Managers
{
    public interface IManager
    {
        IActionResult Execute(object pSouce, IAction pAction);
        IEnumerable<IManager> GetChildren();
        IManager GetParent();
        void AddManager(IManager pManager);
        bool RemoveManager(IManager pManager);

        void Update(object pState);

        void SetController(IController pController);
        IController GetController(Type pControllerType);
        TController GetController<TController>() where TController :  IController;
        IEnumerable<IController> GetControllers();
    }
}
