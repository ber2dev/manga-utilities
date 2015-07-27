using System.Windows;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    /// <summary>
    /// Base class for a TabItem user control.
    /// For Design purpose it mantains both parameter-less constructor and full constructor
    /// </summary>
    public class WindowBase : Window, IController
    {
        private IManager _parent;

        public WindowBase(IManager pManager)
        {
            SetManager(pManager);
        }

        public WindowBase()
            : this(null)
        {
        }

        public IManager GetManager()
        {
            return _parent;
        }

        public void SetManager(IManager pManager)
        {
            _parent = (pManager ?? NotSetManager.INSTANCE);
            _parent.SetController(this);
        }

        public bool IsManager(IManager pManager)
        {
            return ReferenceEquals(pManager, GetManager());
        }

        public virtual void Load(object pState)
        {
        }
    }
}
