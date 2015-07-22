using System.Collections.Generic;

namespace Mu.Client.Infrastructure.Actions
{
    public class CompositeActionResult : IActionResult
    {
        private readonly IList<IActionResult> _actionResults;

        public CompositeActionResult(params IActionResult[] pActionResults)
        {
            _actionResults = new List<IActionResult>(pActionResults);
        }

        public IEnumerable<IActionResult> ActionResults
        {
            get { return _actionResults; }
        }

        public void Add(IActionResult pActionResult)
        {
            AddRange(new []{pActionResult});
        }

        public void AddRange(IEnumerable<IActionResult> pActionResultEnumeration)
        {
            foreach (var actionResult in pActionResultEnumeration)
            {
                _actionResults.Add(actionResult);
            }
        }
    }
}
