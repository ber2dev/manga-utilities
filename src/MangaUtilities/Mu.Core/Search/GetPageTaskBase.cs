using Mu.Core.Common.Tasking;

namespace Mu.Core.Search
{
    public abstract class GetPageTaskBase : ITask
    {
        public abstract void Do();
        public abstract object GetResult();
    }
}
