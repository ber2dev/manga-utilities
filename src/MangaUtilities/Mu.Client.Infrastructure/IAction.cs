namespace Mu.Client.Infrastructure
{
    public interface IAction
    {
        T GetParameter<T>(string name);
        void SetParameter(string name, object value0);
    }
}
