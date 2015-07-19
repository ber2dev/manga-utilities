using System.Windows;
using Mu.Client.Infrastructure;

namespace MangaSharp
{
    public class ApplicationManager : ManagerBase
    {
        private readonly Application _current;

        public ApplicationManager(Application pCurrent)
        {
            _current = pCurrent;
        }

        public override IActionResult Execute(IAction pAction)
        {
            return null;
        }
    }
}
