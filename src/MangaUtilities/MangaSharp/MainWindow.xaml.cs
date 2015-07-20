using System.Collections.Generic;
using Mu.Client.Infrastructure;
using Mu.GoodManga.Ui.Wpf;
using Mu.Main;

namespace MangaSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IComponent
    {
        public MainWindow(IComponent pParent = null)
        {
            InitializeComponent();
            var mainManager = new MainManager(this);
            TabControl.Items.Add(new TabController(mainManager));
        }

        public IActionResult Execute(IAction pAction)
        {
            return new NotAvailableActionResult();
        }

        public IEnumerable<IComponent> GetChildren()
        {
            return new List<IComponent>();
        }

        public IComponent GetParent()
        {
            return NotSetComponent.INSTANCE;
        }

        public void Update(object pState)
        {
        }

        public void AddComponent(IComponent pComponent)
        {
        }

        public bool RemoveComponent(IComponent pComponent)
        {
            return false;
        }
    }
}
