using System.Windows.Controls;
using Mu.Client.Infrastructure;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    public class TabControlBase: TabItem, IController
    {
        private IManager _manager;

        public TabControlBase() { }

        public virtual void SetManager(IManager pManager)
        {
            _manager = pManager;
        }

        public virtual IManager GetManager()
        {
            return _manager;
        }

        public virtual T GetManager<T>()
            where T : IManager
        {
            return (T)_manager;
        }

        public virtual void UpdateState(object pState)
        {
            
        }
    }
}
