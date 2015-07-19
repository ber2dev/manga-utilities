using System.Runtime.Remoting.Channels;
using System.Windows.Controls;
using System.Windows.Input;
using Mu.Core.Common.Hierarchies;

namespace Mu.Main.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for NavigationTreeView.xaml
    /// </summary>
    public partial class NavigationTreeView
    {
        public NavigationTreeView()
        {
            InitializeComponent();
        }

        public override void UpdateState(object state)
        {
            var s = state as ITree;
            if (s == null)
            {
                return;
            }

            TreeView.ItemsSource = s.FirstLevel;
        }

        private void TreeView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var man = GetManager();
            if (man == null)
            {
                return;
            }

            var treeView = sender as TreeView;
            if (treeView == null)
            {
                return;
            }

            var selectedItem = treeView.SelectedItem as INode;
            if (selectedItem == null)
            {
                return;
            }

            var data = selectedItem.Data as Link;
            if (data == null)
            {
                return;
            }

            man.Execute(data.ToAction());
        }
    }
}
