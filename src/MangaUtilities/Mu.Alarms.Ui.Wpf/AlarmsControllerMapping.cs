using System;
using System.Collections.Generic;

namespace Mu.Alarms.Ui.Wpf
{
    public static class AlarmsControllerMapping
    {
        public static readonly IDictionary<Type, Type> Map = new Dictionary<Type, Type>
        {
            {typeof(IAlarmsListController), typeof(AlarmsListView)}
        };
    }
}
