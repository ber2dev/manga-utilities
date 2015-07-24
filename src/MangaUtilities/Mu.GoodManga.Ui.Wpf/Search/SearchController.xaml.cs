using System.Linq;
using System.Windows.Controls;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Actions;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class SearchController
    {
        public SearchController(IComponent pParent)
            : base(pParent)
        {
            InitializeComponent();
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                var childrenResults = ComponentUtilities.ExecuteToChildren(this, new LoadAction(this)) ?? new IActionResult[0];
                return new CompositeActionResult(childrenResults.ToArray());
            }
            if (pAction is AddMangaAction)
            {
                AddManga(pAction as AddMangaAction);
            }

            return base.Execute(pAction);
        }

        private void AddManga(AddMangaAction pAddMangaAction)
        {
            FoundItemsListView.Items.Add(pAddMangaAction.Manga.Sid);
        }

        private void SearchKeyTextBox_OnTextChanged(object pSender, TextChangedEventArgs pE)
        {
            var arguments = pE;
            if (arguments == null
                || arguments.Changes == null
                || !arguments.Changes.Any())
            {
                return;
            }

            var man = GetParent();
            if (man == null)
            {
                return;
            }

            man.Execute(new WebSearchAction(SearchKeyTextBox.Text));
        }
    }
}
