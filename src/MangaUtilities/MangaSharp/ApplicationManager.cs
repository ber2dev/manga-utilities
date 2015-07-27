using System.Windows;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;

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
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pAction);
        }
    }
}
