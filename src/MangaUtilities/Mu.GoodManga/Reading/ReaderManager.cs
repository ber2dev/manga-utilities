using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Reading
{
    public class ReaderManager : ManagerBase
    {
        public ReaderManager(IManager pManager)
            : base(pManager)
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
