using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class GoodMangaTabController
    {
        public GoodMangaTabController(IComponent pParent = null)
            : base(pParent)
        {
            InitializeComponent();

            var goodMangaManager = new GoodMangaManager(this);

            var searchManager = new SearchManager(goodMangaManager);
            TabControl.Items.Add(new Search.SearchTabController(searchManager));
        }
    }
}
