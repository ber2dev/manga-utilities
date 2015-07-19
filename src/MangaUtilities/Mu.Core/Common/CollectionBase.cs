using System.Collections.ObjectModel;

namespace Mu.Core.Common
{
    public abstract class CollectionBase<T> : Collection<T>
    {
        public abstract void Save(IContext pContext);
        public abstract void Load(IContext context);
    }
}
