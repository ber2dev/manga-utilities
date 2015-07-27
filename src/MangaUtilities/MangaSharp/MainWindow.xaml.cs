using System.Windows;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Ui.Wpf;
using Mu.Main;

namespace MangaSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainController
    {
        public MainWindow(IManager pManager)
            : base(pManager)
        {
            InitializeComponent();
            var mainManager = new MainManager(GetManager());
            TabControl.Items.Add(new GoodMangaTabController(mainManager));
        }

        private void MainWindow_OnLoaded(object pSender, RoutedEventArgs pE)
        {
            GetManager().Execute(this, new LoadAction(this));
        }
    }
}
