using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Managers
{
    public class ChapterManager : ManagerBase
    {
        public ChapterManager(IManager pParent)
            : base(pParent)
        {
        }

        public ChapterInformation Chapter { get; set; }

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
