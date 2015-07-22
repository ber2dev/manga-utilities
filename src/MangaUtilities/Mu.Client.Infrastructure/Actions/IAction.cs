namespace Mu.Client.Infrastructure.Actions
{
    public interface IAction
    {
        object GetSource();
        T GetParameter<T>(string pName);
        void SetParameter(string pName, object pValue);
    }
}
