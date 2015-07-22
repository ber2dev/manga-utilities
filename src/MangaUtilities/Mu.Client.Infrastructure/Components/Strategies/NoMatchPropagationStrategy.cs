using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components.Strategies
{
    public class NoMatchPropagationStrategy : IComponentStrategy
    {
        private readonly IComponent _component;
        private readonly bool _toParent;
        private readonly bool _toChildren;

        public NoMatchPropagationStrategy(IComponent pComponent)
            : this(pComponent, true, false)
        {
        }

        public NoMatchPropagationStrategy(
            IComponent pComponent,
            bool pToParent,
            bool pToChildren)
        {
            _component = pComponent;
            _toParent = pToParent;
            _toChildren = pToChildren;
        }

        public IActionResult Execute(IAction pAction)
        {
            var compositeResult = new CompositeActionResult();

            if (_toParent)
            {
                compositeResult.AddRange(ExecuteToParent(pAction));
            }

            if (_toChildren)
            {
                compositeResult.AddRange(ExecuteToChildren(pAction));
            }

            return compositeResult;
        }

        private IEnumerable<IActionResult> ExecuteToChildren(IAction pAction)
        {
            return ComponentUtilities.ExecuteToChildren(_component, pAction);
        }

        private IEnumerable<IActionResult> ExecuteToParent(IAction pAction)
        {
            return ComponentUtilities.ExecuteToParent(_component, pAction);
        }
    }
}
