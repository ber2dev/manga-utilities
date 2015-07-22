using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Ui.Wpf.Download
{
    /// <summary>
    /// Interaction logic for DownloadController.xaml
    /// </summary>
    public partial class DownloadController
    {
        public DownloadController(IComponent pParent = null)
            :base(pParent)
        {
            InitializeComponent();
        }
    }
}
