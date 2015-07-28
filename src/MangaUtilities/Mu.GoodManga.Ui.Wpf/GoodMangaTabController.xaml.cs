using System.Linq;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;
using Mu.GoodManga.Search;
using Mu.GoodManga.Ui.Wpf.Reading;
using Mu.GoodManga.Ui.Wpf.Search;

namespace Mu.GoodManga.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class GoodMangaTabController : IGoodMangaTabController
    {
        public GoodMangaTabController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();

            var goodMangaManager = new GoodMangaManager(GetManager());

            var searchingManager = new SearchingManager(goodMangaManager);
            TabControl.Items.Add(new SearchTabController(searchingManager));

            var readinghManager = new ReadingManager(goodMangaManager);
            TabControl.Items.Add(new ReaderTabController(readinghManager));
        }

        public void ActivateTab(GoodMangaContext pGoodMangaContext)
        {
            var tab = TabControl.Items.OfType<IGoodMangaTab>().FirstOrDefault(x => x.Context == pGoodMangaContext);
            if (tab == null)
            {
                return;
            }

            TabControl.SelectedItem = tab;
        }
    }
}
