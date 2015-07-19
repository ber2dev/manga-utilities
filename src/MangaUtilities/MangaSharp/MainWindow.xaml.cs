using System.Windows;
using Mu.Alarms;
using Mu.Main;

namespace MangaSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var appManager = new ApplicationManager(Application.Current);
            var mainManager = new MainManager(GoodMangaTabController);
            var alarmsManager = new AlarmsManager(appManager);
        }
    }
}
