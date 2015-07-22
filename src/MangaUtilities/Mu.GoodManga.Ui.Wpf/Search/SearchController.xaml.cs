using System.Linq;
using System.Windows.Controls;
using Mu.GoodManga.Actions;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class SearchController
    {
        public SearchController()
        {
            InitializeComponent();
        }

        private void SearchKeyTextBox_OnTextChanged(object pSender, TextChangedEventArgs pE)
        {
            var arguments = pE;
            if (arguments == null
                || arguments.Changes == null
                || arguments.Changes.Any())
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
