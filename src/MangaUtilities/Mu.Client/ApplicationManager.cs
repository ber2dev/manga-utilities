using System.Windows;

namespace Mu.Client
{
    public class ApplicationManager
    {
        private readonly App _app;

        public ApplicationManager(App app)
        {
            _app = app;
        }

        public void Run()
        {
            var applicationWindow = new ApplicationController();
            applicationWindow.Show();
            _app.MainWindow = applicationWindow;
            _app.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
