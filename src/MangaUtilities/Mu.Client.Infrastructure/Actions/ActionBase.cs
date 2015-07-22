using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Mu.Client.Infrastructure.Actions
{
    public class ActionBase : IAction
    {
        private readonly object _source;
        private readonly IDictionary<string, object> _parameters;

        protected ActionBase(object pSource)
        {
            _source = pSource;
            _parameters = new ConcurrentDictionary<string, object>();
        }

        public object GetSource()
        {
            return _source;
        }

        public T GetParameter<T>(string pName)
        {
            object @out;
            if (_parameters.TryGetValue(pName, out @out))
            {
                return (T)@out;
            }

            return default(T);
        }

        public void SetParameter(string pName, object pValue)
        {
            _parameters[pName] = pValue;
        }
    }
}