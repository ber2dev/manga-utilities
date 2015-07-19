namespace Mu.Client.Infrastructure
{
    public class NoAction : IAction
    {
        public T GetParameter<T>(string pName)
        {
            return default (T);
        }

        public void SetParameter(string pName, object pValue)
        {
        }
    }
}
