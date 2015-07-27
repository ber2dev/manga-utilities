using System.Linq;
using System.Windows.Controls;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Actions;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class SearchController : ISearchController
    {
        public SearchController(IManager pParent)
            : base(pParent)
        {
            InitializeComponent();
        }

        public void Load(object pAction)
        {
            // do nothing   
        }

        public void AddManga(MangaInformation pManga)
        {
            FoundItemsListView.Items.Add(pManga.Sid);
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

            var man = GetManager();
            if (man == null)
            {
                return;
            }

            man.Execute(new WebSearchAction(SearchKeyTextBox.Text));
        }
    }
}
