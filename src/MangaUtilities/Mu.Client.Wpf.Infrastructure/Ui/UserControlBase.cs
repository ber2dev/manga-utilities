using System.Windows.Controls;
using Mu.Client.Infrastructure;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    public class UserControlBase : UserControl, IController
    {
        private IManager _manager;

        public UserControlBase() { }

        public virtual void SetManager(IManager manager)
        {
            _manager = manager;
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

        public virtual void UpdateState(object state)
        {
            
        }
    }
}
