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
                var childrenResults = ComponentUtilities.ExecuteToChildren(this, new LoadAction(this)) ?? new IActionResult[0];
                return new CompositeActionResult(childrenResults.ToArray());
            }

            return base.Execute(pAction);
        }
    }
}
