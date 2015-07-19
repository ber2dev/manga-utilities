using System.Windows;
using Mu.Alarms;
using Mu.Alarms.Ui.Wpf;
using Mu.Core.Common.Hierarchies;
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

            var contentManager = new MangaSharpContentLoader(this);

            var navigationManager = new NavigationManager(
                contentManager, 
                NavigationTreeActions, 
                NavigationTree);

            appManager.SetNavigationManager(navigationManager);

            navigationManager.Load(new MangaSharpNavigationTree());

            var alarmsManager = new AlarmsManager(appManager);
        }
    }
}
