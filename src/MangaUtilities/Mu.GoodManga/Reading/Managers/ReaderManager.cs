using System;
using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.Core.Common.Validation;
using Mu.GoodManga.Reading.Actions;
using Mu.GoodManga.Reading.Controllers;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Managers
{
    public class ReaderManager : ManagerBase
    {
        public ReaderManager(IManager pManager)
            : base(pManager)
        {
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            var readMangaAction = pAction as StartReadAction;
            if (readMangaAction != null)
            {
                return ReadManga(readMangaAction);
            }

            return base.Execute(pSouce, pAction);
        }

        private IActionResult ReadManga(StartReadAction pAction)
        {
            ArgumentsValidation.NotNull(pAction, "pAction");

            var items = GetChildren();
            if (items == null)
            {
                return new NotAvailableActionResult();
            }

            var manga = pAction.Manga;

            var itemToActivate = items
                .OfType<MangaReaderManager>()
                .Where(x => x != null && x.Manga != null)
                .FirstOrDefault(x => x.Manga.Equals(manga));

            var chapter = pAction.Chapter ?? ChapterInformation.DEFAULT;
            return itemToActivate == null
                ? StartReadingManga(manga, chapter)
                : StartReadingManga(manga, chapter, itemToActivate);
        }

        private IActionResult StartReadingManga(MangaInformation pManga, ChapterInformation pChapter)
        {
            var reader = CreateNewReader(pManga);
            return StartReadingManga(pManga, pChapter, reader);
        }

        private IActionResult StartReadingManga(MangaInformation pManga, ChapterInformation pChapter, MangaReaderManager pItemToActivate)
        {
            ArgumentsValidation.NotNull(pManga, "pManga");
            ArgumentsValidation.NotNull(pChapter, "pChapter");
            ArgumentsValidation.NotNull(pItemToActivate, "pItemToActivate");

            return pItemToActivate.Execute(this, new StartReadAction(this, pManga, pChapter));
        }

        private MangaReaderManager CreateNewReader(MangaInformation pManga)
        {
            var readerController = GetController<IReaderController>();
            if (readerController == null)
            {
                throw new InvalidOperationException();
            }

            var mangaReaderManager = new MangaReaderManager(this, pManga);
            readerController.CreateReader(mangaReaderManager);
            //MangaReaderTabControl.Items.Add(new MangaReaderController(mangaReaderManager));

            return mangaReaderManager;
        }
    }
}
