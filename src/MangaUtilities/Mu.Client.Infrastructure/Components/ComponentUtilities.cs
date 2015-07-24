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
            IComponent pComponent, 
            IAction pAction,
            bool pCheckSource)
        {
            ArgumentsValidation.NotNull(pComponent, "pComponent");
            ArgumentsValidation.NotNull(pAction, "pAction");

            var result = new List<IActionResult>();

            var children = pComponent.GetChildren();
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

        public static IEnumerable<IActionResult> ExecuteToChildren(IComponent pComponent, IAction pAction)
        {
            return ExecuteToChildren(pComponent, pAction, true);
        }

        public static IEnumerable<IActionResult> ExecuteToParent(
            IComponent pComponent, 
            IAction pAction,
            bool pCheckSource)
        {
            ArgumentsValidation.NotNull(pComponent, "pComponent");
            ArgumentsValidation.NotNull(pAction, "pAction");

            var result = new List<IActionResult>();

            var parent = pComponent.GetParent();
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

        public static IEnumerable<IActionResult> ExecuteToParent(IComponent pComponent, IAction pAction)
        {
            return ExecuteToParent(pComponent, pAction, true);
        }
    }
}
