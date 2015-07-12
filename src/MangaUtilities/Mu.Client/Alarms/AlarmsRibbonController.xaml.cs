using System.Windows;
using Mu.Client.Base;

namespace Mu.Client.Alarms
{
    /// <summary>
    /// Interaction logic for AlarmsRibbonController.xaml
    /// </summary>
    public partial class AlarmsRibbonController
    {
        public AlarmsRibbonController()
        {
            InitializeComponent();
        }

        public AlarmsRibbonController(AlarmsManager manager)
        {
            Manager = manager;
            InitializeComponent();
        }

        public AlarmsManager Manager { get; private set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.Execute(((Fluent.Button) sender).DataContext as IAction);
        }
    }
}
