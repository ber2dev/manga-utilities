using Mu.Client.Infrastructure;

namespace Mu.Alarms
{
    public class AlarmsManager : ManagerBase
    {
        private readonly IManager _parentManager;

        public AlarmsManager(IManager pArentManager)
        {
            _parentManager = pArentManager;
        }

        public override IActionResult Execute(IAction pAction)
        {
            return _parentManager.Execute(pAction);
        }
    }
}
