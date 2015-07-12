using Fluent;
using Mu.Client.Alarms;
using Mu.Client.Base;

namespace Mu.Client.Main
{
    public class MainManager : IManager
    {
        private readonly ApplicationController _controller;

        public MainManager(ApplicationController controller)
        {
            _controller = controller;
            InitAlarms();
        }

        public IActionResult Execute(IAction action)
        {
            return null;
        }

        private void InitAlarms()
        {
            var alarmsManager = new AlarmsManager(this);
            AddHome(alarmsManager.AlarmsRibbonController);
        }

        private void AddHome(RibbonGroupBox groupBox)
        {
            _controller.HomeRibbonTab.Groups.Add(groupBox);
        }
    }
}
