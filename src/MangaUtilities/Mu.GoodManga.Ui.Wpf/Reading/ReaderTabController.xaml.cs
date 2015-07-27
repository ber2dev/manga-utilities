using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class ReaderTabController : IReaderTabController
    {
        public ReaderTabController(IManager pManager)
            :base(pManager)
        {
            InitializeComponent();

            var readerManager = new ReaderManager(GetManager());
            var readerController = new ReaderController(readerManager);

            Content = readerController;
        }
    }
}
