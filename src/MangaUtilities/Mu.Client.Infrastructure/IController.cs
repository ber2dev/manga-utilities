namespace Mu.Client.Infrastructure
{
    public interface IController
    {
        void SetManager(IManager manager);
        void UpdateState(object state);
    }
}
