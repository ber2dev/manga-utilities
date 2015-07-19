using System.Collections.Generic;

namespace Mu.Client.Infrastructure
{
    public interface IManager
    {
        IActionResult Execute(IAction pAction);
        IEnumerable<IController> GetControllers();
    }

    public abstract class ManagerBase : IManager
    {
        private readonly List<IController> _controllers;

        protected ManagerBase(params IController[] pControllers)
        {
            _controllers = new List<IController>((pControllers ?? new IController[0]));
        }

        public virtual IActionResult Execute(IAction pAction)
        {
            return new NotAvailableActionResult();
        }

        public IEnumerable<IController> GetControllers()
        {
            return _controllers.AsReadOnly();
        }
    }
}
