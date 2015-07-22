namespace Mu.Client.Infrastructure.Actions
{
    public class NoAction : IAction
    {
        public object GetSource()
        {
            return null;
        }

        public T GetParameter<T>(string pName)
        {
            return default (T);
        }

        public void SetParameter(string pName, object pValue)
        {
        }
    }
}
