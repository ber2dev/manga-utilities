using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.Core.Common.Validation;
using Mu.GoodManga.Reading.Actions;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Managers
{
    public class MangaReaderManager : ManagerBase
    {
        public MangaReaderManager(IManager pParent, MangaInformation pManga)
            : base(pParent)
        {
            ArgumentsValidation.NotNull(pManga, "pManga");

            Manga = pManga;
        }

        public MangaInformation Manga { get; private set; }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            if (pAction is StartReadAction)
            {
                return ExecuteToChildren(pAction);
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
