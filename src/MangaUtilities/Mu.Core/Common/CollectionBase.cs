using System.Collections.ObjectModel;

namespace Mu.Core.Common
{
    public abstract class CollectionBase<T> : Collection<T>
    {
        public abstract void Save(IContext context);
        public abstract void Load(IContext context);
    }
}
