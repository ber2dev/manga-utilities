using System.Linq;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;
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

            var searchingManager = new SearchingManager(goodMangaManager);
            TabControl.Items.Add(new Search.SearchTabController(searchingManager));

            var readinghManager = new ReadingManager(goodMangaManager);
            TabControl.Items.Add(new Reading.ReaderTabController(readinghManager));
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pAction);
        }
    }
}
