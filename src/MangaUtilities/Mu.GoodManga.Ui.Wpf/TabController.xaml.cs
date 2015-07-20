using Mu.Client.Infrastructure;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for TabController.xaml
    /// </summary>
    public partial class TabController
    {
        public TabController(IComponent pParent = null)
            : base(pParent)
        {
            InitializeComponent();

            var goodMangaManager = new GoodMangaManager(this);

            var searchManager = new SearchManager(goodMangaManager);
            TabControl.Items.Add(new Search.TabController(searchManager));
        }
    }
}
