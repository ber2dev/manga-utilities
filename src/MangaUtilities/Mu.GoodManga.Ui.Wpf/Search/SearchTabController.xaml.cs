using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Search;
using Mu.GoodManga.Search.Controllers;
using Mu.GoodManga.Search.Managers;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class SearchTabController : ISearchTabController
    {
        public SearchTabController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();

            var searchManager = new SearchManager(GetManager());
            Content = new SearchController(searchManager);
        }

        public GoodMangaContext Context { get { return GoodMangaContext.Search; } }
    }
}
