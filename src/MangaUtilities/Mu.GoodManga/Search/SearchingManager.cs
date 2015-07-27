using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Search
{
    public class SearchingManager : ManagerBase
    {
        public SearchingManager(IManager pParent)
            : base(pParent)
        {
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
