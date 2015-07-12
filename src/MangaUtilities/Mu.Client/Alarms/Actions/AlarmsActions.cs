using System.Collections.Generic;
using Mu.Client.Alarms.Actions;

namespace Mu.Client.Alarms
{
    public static class AlarmsActions
    {
        #region Constants

        public static readonly IEnumerable<AbstractAlarmAction> ACTIONS;

        #endregion

        #region Constructors

        static AlarmsActions()
        {
            ACTIONS = new AbstractAlarmAction[]
            {
                new NewAlarmAction(), 
                new DeleteAlarmAction(), 
                new EditAlarmAction(), 
                new NewFromAlarmAction(), 
                new ShowAlarmAction()
            };
        }

        #endregion
    }
}
