namespace Mu.Core.Common.Tasking
{
    public interface ITask
    {
        void Do();
        object GetResult();
    }
}
