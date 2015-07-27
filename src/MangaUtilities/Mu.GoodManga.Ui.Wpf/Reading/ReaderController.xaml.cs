using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class ReaderController : IReaderController
    {
        public ReaderController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
        }

        public void Load(LoadAction pAction)
        {
            
        }

        //public IActionResult ReadManga(ReadMangaAction pAction)
        //{
        //    ArgumentsValidation.NotNull(pAction, "pAction");

        //    var items = GetChildren();
        //    if (items == null)
        //    {
        //        return new NotAvailableActionResult();
        //    }

        //    var manga = pAction.Manga;

        //    var itemToActivate = items
        //        .OfType<MangaReaderManager>()
        //        .Where(x => x != null && x.Manga != null)
        //        .FirstOrDefault(x => x.Manga.Equals(manga));

        //    var chapter = pAction.Chapter;
        //    return itemToActivate == null
        //        ? StartReadingManga(manga, chapter)
        //        : StartReadingManga(manga, chapter, itemToActivate);
        //}

        //private IActionResult StartReadingManga(MangaInformation pManga, ChapterInformation pChapter)
        //{
        //    var reader = CreateNewReader(pManga);
        //    return StartReadingManga(pManga, pChapter, reader);
        //}

        //private IActionResult StartReadingManga(MangaInformation pManga, ChapterInformation pChapter, MangaReaderManager pItemToActivate)
        //{
        //    ArgumentsValidation.NotNull(pManga, "pManga");
        //    ArgumentsValidation.NotNull(pChapter, "pChapter");
        //    ArgumentsValidation.NotNull(pItemToActivate, "pItemToActivate");

        //    return pItemToActivate.Execute(new StartReadAction(this, pManga, pChapter));
        //}

        //private MangaReaderManager CreateNewReader(MangaInformation pManga)
        //{
        //    var mangaReaderManager = new MangaReaderManager(this, pManga);
        //    MangaReaderTabControl.Items.Add(new MangaReaderController(mangaReaderManager));

        //    return mangaReaderManager;
        //}
    }
}
