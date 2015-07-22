using System.Collections.Generic;
using Mu.Core.Common.Validation;

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
            ArgumentsValidation.NotNull(pActionResult, "pActionResult");

            AddRange(new []{pActionResult});
        }

        public void AddRange(IEnumerable<IActionResult> pActionResultEnumeration)
        {
            ArgumentsValidation.NotNull(pActionResultEnumeration, "pActionResultEnumeration");

            foreach (var actionResult in pActionResultEnumeration)
            {
                _actionResults.Add(actionResult);
            }
        }
    }
}
