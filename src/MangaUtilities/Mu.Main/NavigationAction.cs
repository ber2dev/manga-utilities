using System;
using System.Collections.Generic;
using Mu.Client.Infrastructure;

namespace Mu.Main
{
    public class NavigationAction : IAction
    {
        private readonly Dictionary<string, object> _parameters;

        public NavigationAction(Type viewType)
        {
            _parameters = new Dictionary<string, object> { { "View", viewType } };
        }

        public T GetParameter<T>(string name)
        {
            return (T)_parameters[name];
        }

        public void SetParameter(string name, object value)
        {
            _parameters[name] = value;
        }
    }
}
