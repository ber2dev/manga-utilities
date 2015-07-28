using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Reading;
using Mu.GoodManga.Reading.Controllers;

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
