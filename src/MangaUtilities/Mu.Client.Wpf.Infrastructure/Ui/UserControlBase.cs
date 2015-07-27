using System.Windows.Controls;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    /// <summary>
    /// Base class for a basic user control.
    /// For Design purpose it mantains both parameter-less constructor and full constructor
    /// </summary>
    public class UserControlBase : UserControl, IController
    {
        private IManager _parent;

        public UserControlBase(IManager pManager)
        {
            SetManager(pManager);
        }

        public UserControlBase()
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
    }
}
