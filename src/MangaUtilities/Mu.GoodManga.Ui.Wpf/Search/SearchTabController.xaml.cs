using System.Linq;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class SearchTabController
    {
        public SearchTabController(IComponent pParent)
            : base(pParent)
        {
            InitializeComponent();

            var searchManager = new SearchManager(this);
            Content = new SearchController(searchManager);
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
