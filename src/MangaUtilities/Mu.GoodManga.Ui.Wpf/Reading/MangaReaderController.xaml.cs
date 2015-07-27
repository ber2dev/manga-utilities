using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for MangaReaderController.xaml
    /// </summary>
    public partial class MangaReaderController : IMangaReaderController
    {
        public MangaReaderController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
        }

        public void Load(LoadAction pAction)
        {
            //do nothing
        }

        //public void StartRead(StartReadAction pStartReadAction)
        //{
        //    ArgumentsValidation.NotNull(pStartReadAction, "pStartReadAction");

        //    var mangaInformation = pStartReadAction.Manga;
        //    var chapterInformation = pStartReadAction.Chapter;

        //    var chapterManager = GetChapterManager(chapterInformation);
        //    if (chapterManager == null)
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    chapterManager.Execute(new ReadChapterAction(this));
        //}

        //private ChapterManager GetChapterManager(ChapterInformation pChapterInformation)
        //{
        //    ArgumentsValidation.NotNull(pChapterInformation);

        //    if (IsChapterOpen(pChapterInformation))
        //    {
        //        return GetChildren().OfType<ChapterManager>().First(x => pChapterInformation.Equals(x.Chapter));
        //    }

        //    var chapterManager = new ChapterManager(this);
        //    ReadingChaptersTabControl.Items.Add(
        //        new TabItem()
        //        {
        //            Header = string.Format("{0} {1}", GetParent(), chapterManager.Chapter.Number),
        //            Content = new ChapterController(chapterManager)
        //        });

        //    return chapterManager;
        //}

        //private bool IsChapterOpen(ChapterInformation pChapterInformation)
        //{
        //    ArgumentsValidation.NotNull(pChapterInformation);

        //    var isMangaOpen = GetChildren().OfType<ChapterManager>().Any(x => pChapterInformation.Equals(x.Chapter));
        //    return isMangaOpen;
        //}
    }
}
