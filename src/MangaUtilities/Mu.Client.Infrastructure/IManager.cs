using System.Collections.Generic;

namespace Mu.Client.Infrastructure
{
    public interface IManager
    {
        IActionResult Execute(IAction action);
        IEnumerable<IController> GetControllers();
    }

    public abstract class ManagerBase : IManager
    {
        private readonly List<IController> _controllers;

        protected ManagerBase(params IController[] controllers)
        {
            _controllers = new List<IController>((controllers ?? new IController[0]));
        }

        public virtual IActionResult Execute(IAction action)
        {
            return new NotAvailableActionResult();
        }

        public IEnumerable<IController> GetControllers()
        {
            return _controllers.AsReadOnly();
        }
    }
}
