using Mu.Client.Base;

namespace Mu.Client.Alarms.Actions
{
    public abstract class AbstractAlarmAction : AbstractAction
    {
        #region Constructors

        protected AbstractAlarmAction(bool isAvailable)
            :base(isAvailable)
        {
        }

        #endregion

        #region Protected

        protected override string Module
        {
            get { return AlarmsModule.ModuleName; }
        }

        #endregion
    }
}