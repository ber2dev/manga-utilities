using System.Windows;

namespace MangaSharp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static readonly Thickness STANDARD_MARGIN = new Thickness(2);

        protected override void OnStartup(StartupEventArgs pE)
        {
            base.OnStartup(pE);

            var applicationManager = new ApplicationManager(this);
            var window = new MainWindow(applicationManager);
            MainWindow = window;
            ShutdownMode = ShutdownMode.OnMainWindowClose;

            MainWindow.Show();
        }
    }
}
