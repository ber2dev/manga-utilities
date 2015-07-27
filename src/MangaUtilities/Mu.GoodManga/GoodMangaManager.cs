using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga
{
    public class GoodMangaManager : ManagerBase
    {
        public GoodMangaManager(IManager pParentManager)
            : base(pParentManager)
        {
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            if (pAction is ReadMangaAction)
            {
                return ExecuteToChildren(pAction);
            }

            return base.Execute(pAction);
        }
    }
}
