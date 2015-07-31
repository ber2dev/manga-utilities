using System;
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
        #region Constants
        private const int STARTING_PAGE = 1; 
        #endregion

        #region Constructors
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
        #endregion

        #region Public
        public MangaInformation Manga
        {
            get { return _manga; }
        }

        public IEnumerable<ChapterInformation> Chapters
        {
            get { return _chapters; }
        }

        public ChapterInformation SelectedChapter
        {
            get { return _selectedChapter; }
            set { _selectedChapter = value; }
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
                return StartRead(startReadAction);
            }

            var selectItemAction = pAction as SelectItemAction;
            if (selectItemAction != null)
            {
                try
                {
                    SelectItem(selectItemAction);
                }
                catch (InvalidOperationException ex)
                {
                    //TODO: manage exception: log it and show any information to the user?
                    SelectedChapter = null;
                }
            }

            var startReadSelectedChapterAction = pAction as StartReadSelectedChapterAction;
            if (startReadSelectedChapterAction != null)
            {
                return StartReadSelectedChapter(startReadSelectedChapterAction);
            }

            return base.Execute(pSouce, pAction);
        } 
        #endregion

        #region Private
        #region Fields
        private readonly IList<ChapterInformation> _chapters;
        private readonly MangaInformation _manga;
        private ChapterInformation _selectedChapter;
        #endregion

        #region Methods
        private IActionResult StartReadSelectedChapter(StartReadSelectedChapterAction pStartReadSelectedChapterAction)
        {
            ArgumentsValidation.NotNull(pStartReadSelectedChapterAction, "pStartReadSelectedChapterAction");

            return DoStartRead(SelectedChapter);
        }

        private void SelectItem(SelectItemAction pSelectItemAction)
        {
            ArgumentsValidation.NotNull(pSelectItemAction, "pSelectItemAction");
            var item = pSelectItemAction.SelectedItem as ChapterInformation;
            if (item == null)
            {
                throw new InvalidOperationException("Cannot selected an item that is not a chapter");
            }

            if (!_chapters.Contains(item))
            {
                throw new InvalidOperationException("Cannot select an item that is not in list");
            }

            SelectChapter(item);
        }

        private void SelectChapter(ChapterInformation pItem)
        {
            SelectedChapter = pItem;
            GetController<IMangaReaderController>().SelectChapter(SelectedChapter);
        }

        private IActionResult StartRead(StartReadAction pStartReadAction)
        {
            ArgumentsValidation.NotNull(pStartReadAction, "pStartReadAction");

            return DoStartRead(pStartReadAction.Chapter);
        }

        private IActionResult DoStartRead(ChapterInformation pChapter)
        {
            if (IsChapterMissing(pChapter))
            {
                AddChapter(pChapter);
            }

            SelectChapter(pChapter);
            StartReadSelectedChapter();

            return new NotAvailableActionResult();
        }

        private void StartReadSelectedChapter()
        {
            if (SelectedChapter == null)
            {
                return;
            }

            var reader = GetChapterManager(SelectedChapter);
            if (reader == null)
            {
                reader = AddChapterManager(SelectedChapter);
            }

            if (reader == null)
            {
                throw new InvalidOperationException("Cannot find manager for chapter " + SelectedChapter.Number);
            }

            reader.Execute(this, new ReadAction(STARTING_PAGE));
        }

        private bool IsChapterMissing(ChapterInformation pChapter)
        {
            ArgumentsValidation.NotNull(pChapter, "pChapter");

            var exists = _chapters.Any(x => Equals(x, pChapter));
            return exists;
        }

        private IManager AddChapterManager(ChapterInformation pChapterToAdd)
        {
            var chapterManager = new ChapterManager(this, pChapterToAdd);
            GetController<IMangaReaderController>().CreateChapterReader(chapterManager);
            return chapterManager;
        }

        private void AddChapter(ChapterInformation pChapterToRead)
        {
            _chapters.Add(pChapterToRead);
            GetController<IMangaReaderController>().AddChapter(pChapterToRead);
        }

        private IManager GetChapterManager(ChapterInformation pChapter)
        {
            var manager = GetChildren()
                .OfType<ChapterManager>()
                .FirstOrDefault(x => Equals(x.Chapter, pChapter));

            return manager;
        }
        #endregion
        #endregion

        #region Neteds Types
        private class StartReadParameters
        {
            private readonly IAction _sourceAction;
            private readonly ChapterInformation _chapter;

            public StartReadParameters(IAction pSourceAction, ChapterInformation pChapter)
            {
                _sourceAction = pSourceAction;
                _chapter = pChapter;
            }

            public IAction SourceAction
            {
                get { return _sourceAction; }
            }

            public ChapterInformation Chapter
            {
                get { return _chapter; }
            }
        } 
        #endregion
    }
}
