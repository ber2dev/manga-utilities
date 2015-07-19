using Mu.Client.Infrastructure;

namespace Mu.Alarms
{
    public class AlarmsManager : ManagerBase
    {
        private readonly IManager _parentManager;

        public AlarmsManager(IManager parentManager)
        {
            _parentManager = parentManager;
        }

        public override IActionResult Execute(IAction action)
        {
            return _parentManager.Execute(action);
        }
    }
}
