using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Core.Common.Validation;

namespace Mu.Client.Infrastructure.Components
{
    public static class ComponentUtilities
    {
        public static IEnumerable<IActionResult> ExecuteToChildren(
            IManager pManager, 
            IAction pAction,
            bool pCheckSource)
        {
            ArgumentsValidation.NotNull(pManager, "pManager");
            ArgumentsValidation.NotNull(pAction, "pAction");

            var result = new List<IActionResult>();

            var children = pManager.GetChildren();
            if (children != null)
            {
                var checkedChildren = children.Where(x => !pCheckSource || !ReferenceEquals(x, pAction.GetSource()));
                foreach (var child in checkedChildren)
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

        public static IEnumerable<IActionResult> ExecuteToChildren(IManager pManager, IAction pAction)
        {
            return ExecuteToChildren(pManager, pAction, true);
        }

        public static IEnumerable<IActionResult> ExecuteToParent(
            IManager pManager, 
            IAction pAction,
            bool pCheckSource)
        {
            ArgumentsValidation.NotNull(pManager, "pManager");
            ArgumentsValidation.NotNull(pAction, "pAction");

            var result = new List<IActionResult>();

            var parent = pManager.GetParent();
            if (parent != null && (!pCheckSource || !ReferenceEquals(parent, pAction.GetSource())))
            {
                var r = parent.Execute(pAction);
                if (r != null && !(r is NotAvailableActionResult))
                {
                    result.Add(r);
                }
            }

            return new ReadOnlyCollection<IActionResult>(result);
        }

        public static IEnumerable<IActionResult> ExecuteToParent(IManager pManager, IAction pAction)
        {
            return ExecuteToParent(pManager, pAction, true);
        }
    }
}
