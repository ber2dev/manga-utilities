using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for PageController.xaml
    /// </summary>
    public partial class PageController : IPageController
    {
        public PageController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
        }
    }
}
