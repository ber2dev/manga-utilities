using System.Collections.Generic;

namespace Mu.Core.Common.Hierarchies
{
    public interface ITree
    {
        Node Root { get; }
        IEnumerable<Node> FirstLevel { get; }
    }
}