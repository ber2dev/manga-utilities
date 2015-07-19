using System;
using Mu.Alarms.Ui.Wpf;
using Mu.Client.Infrastructure;
using Mu.Client.Wpf.Infrastructure.Ui;
using Mu.Main;

namespace MangaSharp
{
    public class MangaSharpContentLoader : IContentLoader
    {
        private readonly MainWindow _mainWindow;

        public MangaSharpContentLoader(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Load(INavigationContext content)
        {
            var controllerType = content.GetViewType();
            var viewType = AlarmsControllerMapping.Map[controllerType];
            var instance = Activator.CreateInstance(viewType);
            _mainWindow.ContentGrid.Children.Add((UserControlBase) instance);
        }
    }
}
