using System.Collections.Generic;

namespace Mu.Core.Common.Hierarchies
{
    public class Node : INode
    {
        private Node _parent;
        private object _data;
        private readonly List<Node> _children;

        public Node(object data, Node parent = null)
        {
            _data = data;
            _parent = parent;
            _children = new List<Node>();

            Initialize();
        }

        public IEnumerable<Node> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        public bool HasData
        {
            get { return Data != null; }
        }

        public bool HasParent
        {
            get { return Parent != null; }
        }

        public void Dispose()
        {
            DetachFromParent();
            foreach (var child in _children)
            {
                var current = child;
                current.DetachFromParent();
            }
        }

        protected void AttachToParent()
        {
            if (!HasParent)
            {
                return;
            }

            Parent.AddChild(this);
        }

        protected Node DetachFromParent()
        {
            if (!HasParent)
            {
                return null;
            }

            var parent = Parent;
            Parent.RemoveChild(this);
            Parent = null;
            return parent;
        }

        private void AddChild(Node node)
        {
            _children.Add(node);
        }

        private void RemoveChild(Node node)
        {
            _children.Remove(node);
        }

        private void Initialize()
        {
            AttachToParent();
        }
    }
}
