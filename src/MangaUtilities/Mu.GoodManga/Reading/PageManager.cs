using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Reading
{
    public class PageManager : ComponentBase
    {
        public PageManager(IComponent pParent)
            : base(pParent)
        {
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                var childrenResults = ComponentUtilities.ExecuteToChildren(this, new LoadAction(this)) ?? new IActionResult[0];
                return new CompositeActionResult(childrenResults.ToArray());
            }

            return base.Execute(pAction);
        }
    }
}
