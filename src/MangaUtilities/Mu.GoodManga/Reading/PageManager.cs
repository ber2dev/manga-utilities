using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Reading
{
    public class PageManager : ManagerBase
    {
        public PageManager(IManager pParent)
            : base(pParent)
        {
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
