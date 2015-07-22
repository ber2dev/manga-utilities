using Mu.Core.Common;
using Mu.Core.Common.Tasking;

namespace Mu.Core.Search
{
    public abstract class SearchTaskBase : ITask
    {
        public abstract void Do();
        public abstract object GetResult();
    }
}
