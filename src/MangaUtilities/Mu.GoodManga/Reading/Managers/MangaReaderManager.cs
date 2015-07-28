using System.Collections.Generic;
using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.Core.Common.Validation;
using Mu.GoodManga.Reading.Actions;
using Mu.GoodManga.Reading.Controllers;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Managers
{
    public class MangaReaderManager : ManagerBase
    {
        private const int STARTING_PAGE = 1;

        private readonly IList<ChapterInformation> _chapters;
        private readonly MangaInformation _manga;

        public MangaReaderManager(IManager pParent, MangaInformation pManga, IEnumerable<ChapterInformation> pChapters)
            : base(pParent)
        {
            ArgumentsValidation.NotNull(pManga, "pManga");

            _manga = pManga;
            _chapters = new List<ChapterInformation>(pChapters ?? new List<ChapterInformation>());
        }

        public MangaReaderManager(IManager pParent, MangaInformation pManga)
            : this(pParent, pManga, null)
        {
        }

        public MangaInformation Manga
        {
            get { return _manga; }
        }

        public IEnumerable<ChapterInformation> Chapters
        {
            get { return _chapters; }
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            var startReadAction = pAction as StartReadAction;
            if (startReadAction != null)
            {
                var chapterToRead = _chapters.FirstOrDefault(x => x.Equals(startReadAction.Chapter));
                var isNewChapter = chapterToRead == null;
                if (isNewChapter)
                {
                    chapterToRead = ChapterInformation.DEFAULT;
                    _chapters.Add(chapterToRead);
                }

                if (isNewChapter)
                {
                    // have to create chapter reader
                    CreateChapterItem(chapterToRead);
                }

                // get chapter reader
                var reader = GetChapterManager(chapterToRead);
                if (reader == null)
                {
                    // TODO: throw fail operation
                    return GetCannotExecuteActionResult(pAction);
                }

                // start read
                reader.Execute(this, new ReadAction(STARTING_PAGE));
            }

            return base.Execute(pSouce, pAction);
        }

        private void CreateChapterItem(ChapterInformation pChapterToRead)
        {
            var chapterManager = new ChapterManager(this, pChapterToRead);
            GetController<IMangaReaderController>().CreateChapterReader(chapterManager);
        }

        private IManager GetChapterManager(ChapterInformation pChapter)
        {
            return null;
        }
    }
}
