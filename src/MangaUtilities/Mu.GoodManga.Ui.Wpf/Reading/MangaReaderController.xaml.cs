using System.Windows.Controls;
using System.Windows.Input;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading.Actions;
using Mu.GoodManga.Reading.Controllers;
using Mu.GoodManga.Search;

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

        public void SelectChapter(ChapterInformation pChapter)
        {
            ChaptersList.SelectedItem = pChapter;
        }

        public void AddChapter(ChapterInformation pChapter)
        {
            ChaptersList.Items.Add(pChapter);
        }

        private void ChaptersList_OnMouseDoubleClick(object pSender, MouseButtonEventArgs pE)
        {
            GetManager().Execute(this, new StartReadSelectedChapterAction(null));
        }

        private void ChaptersList_OnSelectionChanged(object pSender, SelectionChangedEventArgs pE)
        {
            GetManager().Execute(this, new SelectItemAction(this, ChaptersList.SelectedItem));
        }
    }
}
