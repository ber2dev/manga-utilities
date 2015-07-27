using System.Collections.Generic;
using Mu.Client.Infrastructure.Actions;

namespace Mu.Client.Infrastructure.Components.Strategies
{
    public class NoMatchPropagationStrategy : IComponentStrategy
    {
        private readonly IManager _manager;
        private readonly bool _toParent;
        private readonly bool _toChildren;

        public NoMatchPropagationStrategy(IManager pManager)
            : this(pManager, true, false)
        {
        }

        public NoMatchPropagationStrategy(
            IManager pManager,
            bool pToParent,
            bool pToChildren)
        {
            _manager = pManager;
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
            return ComponentUtilities.ExecuteToChildren(_manager, pAction);
        }

        private IEnumerable<IActionResult> ExecuteToParent(IAction pAction)
        {
            return ComponentUtilities.ExecuteToParent(_manager, pAction);
        }
    }
}
