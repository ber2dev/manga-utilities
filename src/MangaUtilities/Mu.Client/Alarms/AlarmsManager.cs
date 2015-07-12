using System.Collections.Generic;
using System.Linq;
using Mu.Client.Alarms.Actions;
using Mu.Client.Base;

namespace Mu.Client.Alarms
{
    public class AlarmsManager : IManagerHolder, IManager
    {
        private readonly IManager _holdedManager;
        private readonly IEnumerable<AbstractAlarmAction> _actions;
        private readonly AlarmsRibbonController _alarmsRibbonController;

        public AlarmsManager(IManager holdedManager)
        {
            _holdedManager = holdedManager;
            _actions = AlarmsActions.ACTIONS.ToArray();
            _alarmsRibbonController = new AlarmsRibbonController(this);
        }

        public IEnumerable<AbstractAlarmAction> Actions
        {
            get { return _actions; }
        }

        public AlarmsRibbonController AlarmsRibbonController
        {
            get { return _alarmsRibbonController; }
        }

        public IManager HoldedManager
        {
            get { return _holdedManager; }
        }

        public IActionResult Execute(IAction action)
        {
            if (action == null)
            {
                return null;
            }

            return null;
        }
    }
}
