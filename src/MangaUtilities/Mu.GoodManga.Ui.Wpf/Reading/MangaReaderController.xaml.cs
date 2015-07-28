using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;
using Mu.GoodManga.Reading.Controllers;

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

        public void CreateChapterReader(IManager pManager)
        {
            var chapterController = new ChapterController(pManager);
            ReadingChaptersTabControl.Items.Add(chapterController);
        }
    }
}
