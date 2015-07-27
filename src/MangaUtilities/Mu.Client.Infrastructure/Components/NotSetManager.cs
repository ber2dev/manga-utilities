using System;
using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.Client.Infrastructure.Components
{
    public sealed class NotSetManager : IManager
    {
        public static readonly IManager INSTANCE = new NotSetManager();

        private NotSetManager()
        {
        }

        public IActionResult Execute(IAction pAction)
        {
            return new NotAvailableActionResult();
        }

        public IEnumerable<IManager> GetChildren()
        {
            return new IManager[0];
        }

        public IManager GetParent()
        {
            return INSTANCE;
        }

        public void Update(object pState)
        {
        }

        public void AddManager(IManager pManager)
        {
            
        }

        public bool RemoveManager(IManager pManager)
        {
            return false;
        }

        public void SetController(IController pController)
        {
        }

        public IController GetController(Type pControllerType)
        {
            return null;
        }

        public TController GetController<TController>() where TController : IController
        {
            return default(TController);
        }

        public IEnumerable<IController> GetControllers()
        {
            return new IController[0];
        }
    }
}
