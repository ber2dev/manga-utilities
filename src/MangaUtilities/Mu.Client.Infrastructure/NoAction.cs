namespace Mu.Client.Infrastructure
{
    public class NoAction : IAction
    {
        public T GetParameter<T>(string name)
        {
            return default (T);
        }

        public void SetParameter(string name, object value0)
        {
        }
    }
}
