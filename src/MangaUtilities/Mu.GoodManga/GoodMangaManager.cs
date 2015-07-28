using Mu.Client.Infrastructure.Actions;
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

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            var readMangaAction = pAction as ReadMangaAction;
            if (readMangaAction != null)
            {
                var result = ExecuteToChildren(
                    new StartReadAction(
                        this, 
                        readMangaAction.Manga, 
                        readMangaAction.Chapter));

                GetParent().GetController<IGoodMangaTabController>().ActivateTab(GoodMangaContext.Read);

                return result;
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
