using System.Windows;
using Mu.Alarms;

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

            var alarmsManager = new AlarmsManager(appManager);
        }
    }
}
