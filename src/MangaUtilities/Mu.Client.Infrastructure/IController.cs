namespace Mu.Client.Infrastructure
{
    public interface IController
    {
        void SetManager(IManager pManager);
        void UpdateState(object pState);
    }
}
