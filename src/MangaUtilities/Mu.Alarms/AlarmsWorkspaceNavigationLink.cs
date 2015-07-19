using Mu.Main;

namespace Mu.Alarms.Ui.Wpf
{
    public class AlarmsWorkspaceCategoryLink : CategoryLink
    {
        public AlarmsWorkspaceCategoryLink()
            : base("Alarms", "Alarms section")
        {
        }
    }

    public class AlarmsWorkspaceNavigationLink : NavigationLink
    {
        public AlarmsWorkspaceNavigationLink() 
            : base("List", "Show the list of alarms", typeof(IAlarmsListController))
        {
        }
    }
}
