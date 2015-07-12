using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using Mu.Client.Alarms;

namespace Mu.Client.Base
{
    public abstract class AbstractAction : IAction
    {
        #region Constructors

        protected AbstractAction(bool isAvailable)
        {
            Action = GetAction();
            Description = GetDescription();
            _iconLazy = new Lazy<BitmapSource>(GetIcon);
            IsAvailable = isAvailable;
        }

        #endregion

        #region Public

        public string Action { get; private set; }
        public string Description { get; private set; }
        public BitmapSource Icon { get { return _iconLazy.Value; } }
        public bool IsAvailable { get; private set; }

        #endregion

        #region Protected

        protected abstract string Module { get; }
		 
	    #endregion

        #region Private

        private readonly Lazy<BitmapSource> _iconLazy;

        private BitmapSource GetIcon()
        {
            try
            {
                return new ResourceManagerHelper(AlarmsResources.ResourceManager)
                    .GetIcon(string.Format("{0}Icon", GetType().Name), Module);
            }
            catch (InvalidOperationException ex)
            {
                Trace.TraceError(ex.Message);
                return null;
            }
        }

        private string GetAction()
        {
            try
            {
                return new ResourceManagerHelper(AlarmsResources.ResourceManager)
                        .GetString(string.Format("{0}_Action", GetType().Name));
            }
            catch (InvalidOperationException ex)
            {
                Trace.TraceError(ex.Message);
                return "";
            }
        }

        private string GetDescription()
        {
            try
            {
                return new ResourceManagerHelper(AlarmsResources.ResourceManager)
                        .GetString(string.Format("{0}_Description", GetType().Name));
            }
            catch (InvalidOperationException ex)
            {
                Trace.TraceError(ex.Message);
                return "";
            }
        } 
        
        #endregion
    }
}
