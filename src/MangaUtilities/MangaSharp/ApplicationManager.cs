using System.Windows;
using Mu.Client.Infrastructure;
using Mu.Main;

namespace MangaSharp
{
    public class ApplicationManager : ManagerBase
    {
        private IManager _navigationManager;

        public ApplicationManager(Application current)
        {
            
        }

        public void SetNavigationManager(IManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public override IActionResult Execute(IAction action)
        {
            if (action is NavigationAction)
            {
                if (_navigationManager != null)
                {
                    return _navigationManager.Execute(action);
                }
            }

            return null;
        }
    }
}
