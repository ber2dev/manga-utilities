using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Core.Common.Validation;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading
{
    public class MangaReaderManager : ComponentBase
    {
        public MangaReaderManager(IComponent pParent, MangaInformation pManga)
            : base(pParent)
        {
            ArgumentsValidation.NotNull(pManga, "pManga");

            Manga = pManga;
        }

        public MangaInformation Manga { get; private set; }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                var childrenResults = ComponentUtilities.ExecuteToChildren(this, new LoadAction(this)) ?? new IActionResult[0];
                return new CompositeActionResult(childrenResults.ToArray());
            }

            return base.Execute(pAction);
        }
    }
}
