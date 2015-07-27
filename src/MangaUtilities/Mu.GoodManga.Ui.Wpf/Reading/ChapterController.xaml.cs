using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga.Ui.Wpf.Reading
{
    /// <summary>
    /// Interaction logic for ChapterController.xaml
    /// </summary>
    public partial class ChapterController : IChapterController
    {
        public ChapterController(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
        }
    }
}
