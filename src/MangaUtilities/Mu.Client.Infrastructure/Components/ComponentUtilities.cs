using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components
{
    public static class ComponentUtilities
    {
        public static IEnumerable<IActionResult> ExecuteToChildren(IComponent pComponent, IAction pAction)
        {
            var result = new List<IActionResult>();

            var children = pComponent.GetChildren();
            if (children != null)
            {
                foreach (var child in children)
                {
                    var r = child.Execute(pAction);
                    if (r == null || r is NotAvailableActionResult)
                    {
                        continue;
                    }

                    result.Add(r);
                }
            }

            return new ReadOnlyCollection<IActionResult>(result);
        }

        public static IEnumerable<IActionResult> ExecuteToParent(IComponent pComponent, IAction pAction)
        {
            var result = new List<IActionResult>();

            var parent = pComponent.GetParent();
            if (parent != null)
            {
                var r = parent.Execute(pAction);
                if (r != null && !(r is NotAvailableActionResult))
                {
                    result.Add(r);
                }
            }

            return new ReadOnlyCollection<IActionResult>(result);
        }
    }
}
