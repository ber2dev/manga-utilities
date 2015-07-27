using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Search;

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
    }
}
