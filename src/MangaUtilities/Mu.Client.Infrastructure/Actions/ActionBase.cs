using System.Collections.Concurrent;
using System.Collections.Generic;
using Mu.Core.Common.Validation;

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
            ArgumentsValidation.NotNull(pName, "pName");

            object @out;
            if (_parameters.TryGetValue(pName, out @out))
            {
                return (T)@out;
            }

            return default(T);
        }

        public void SetParameter(string pName, object pValue)
        {
            ArgumentsValidation.NotNull(pName, "pName");

            _parameters[pName] = pValue;
        }
    }
}