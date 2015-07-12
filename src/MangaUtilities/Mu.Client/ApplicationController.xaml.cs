using Mu.Client.Alarms;
using Mu.Client.Base;
using Mu.Client.Main;

namespace Mu.Client
{
    /// <summary>
    /// Interaction logic for ApplicationController.xaml
    /// </summary>
    public partial class ApplicationController : IManager
    {
        public ApplicationController()
        {
            InitializeComponent();
            InitMain();
        }

        private void InitMain()
        {
            var main = new MainManager(this);
        }

        public IActionResult Execute(IAction action)
        {
            return null;
        }
    }
}
