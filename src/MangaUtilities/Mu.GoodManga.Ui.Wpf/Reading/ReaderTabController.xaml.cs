using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;
using Mu.GoodManga.Reading.Controllers;
using Mu.GoodManga.Reading.Managers;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class ReaderTabController : IReaderTabController
    {
        public ReaderTabController(IManager pManager)
            :base(pManager)
        {
            InitializeComponent();

            var readerManager = new ReaderManager(GetManager());
            var readerController = new ReaderController(readerManager);

            Content = readerController;
        }

        public GoodMangaContext Context { get { return GoodMangaContext.Read;} }
    }
}
