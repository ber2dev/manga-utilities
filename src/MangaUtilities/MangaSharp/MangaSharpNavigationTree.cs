using Mu.Alarms.Ui.Wpf;
using Mu.Core.Common.Hierarchies;
using Mu.Main;

namespace MangaSharp
{
    public class MangaSharpNavigationTree : Tree
    {

        public MangaSharpNavigationTree()
            : base(CreateRoot())
        {
            var alarmsMainNode = new Node(new AlarmsWorkspaceCategoryLink(), Root);
            var alarmsListNode = new Node(new AlarmsWorkspaceNavigationLink(), alarmsMainNode);
        }

        private static Node CreateRoot()
        {
            return new MangaSharpNavigationTreeRootNode(null);
        }
    }

    public class MangaSharpNavigationTreeRootNode : Node
    {
        public MangaSharpNavigationTreeRootNode(object data, Node parent = null)
            : base(data, parent)
        {
        }
    }
}
