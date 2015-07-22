using System.Windows;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Ui.Wpf;
using Mu.Main;

namespace MangaSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(IComponent pParent = null)
            : base(pParent)
        {
            InitializeComponent();
            var mainManager = new MainManager(this);
            TabControl.Items.Add(new GoodMangaTabController(mainManager));
        }

        private void MainWindow_OnLoaded(object pSender, RoutedEventArgs pE)
        {
            foreach (var child in GetChildren())
            {
                child.Execute(new LoadAction(this));
            }
        }
    }
}
