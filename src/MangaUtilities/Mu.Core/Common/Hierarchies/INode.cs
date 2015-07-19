using System;
using System.Collections.Generic;

namespace Mu.Core.Common.Hierarchies
{
    public interface INode : IDisposable
    {
        object Data { get; set; }
        Node Parent { get; }
        IEnumerable<Node> Children { get; }
        bool HasData { get; }
        bool HasParent { get; }
    }
}