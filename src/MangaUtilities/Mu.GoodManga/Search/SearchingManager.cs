using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Search
{
    public class SearchingManager : ManagerBase
    {
        public SearchingManager(IManager pParent)
            : base(pParent)
        {
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (!CanExecute(pAction))
            {
                return GetCannotExecuteActionResult(pAction);
            }

            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
