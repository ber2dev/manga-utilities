using System.Collections.Generic;

namespace Mu.Core.Common.Hierarchies
{
    public class Tree : ITree
    {
        private readonly Node _root;

        public Tree(Node root = null)
        {
            _root = root;
        }

        public Node Root
        {
            get { return _root; }
        }

        public IEnumerable<Node> FirstLevel
        {
            get { return Root.Children; }
        }
    }
}
