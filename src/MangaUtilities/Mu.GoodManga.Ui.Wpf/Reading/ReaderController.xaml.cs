using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;
using Mu.GoodManga.Reading.Controllers;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class ReaderController : IReaderController
    {
        public ReaderController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
        }

        public void Load(LoadAction pAction)
        {
            
        }

        public void CreateReader(IManager pManager)
        {
            MangaReaderTabControl.Items.Add(new MangaReaderController(pManager));
        }
    }
}
