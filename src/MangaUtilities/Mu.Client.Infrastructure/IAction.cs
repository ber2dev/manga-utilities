namespace Mu.Client.Infrastructure
{
    public interface IAction
    {
        T GetParameter<T>(string pName);
        void SetParameter(string pName, object pValue);
    }
}
