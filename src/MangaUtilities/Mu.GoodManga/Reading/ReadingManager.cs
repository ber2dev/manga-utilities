using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Reading
{
    public class ReadingManager : ComponentBase
    {
        public ReadingManager(IComponent pParent)
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
            
            if (pAction is ReadMangaAction)
            {
                var results = ComponentUtilities.ExecuteToChildren(this, pAction).ToArray();
                return new CompositeActionResult(results);
            }

            return base.Execute(pAction);
        }
    }
}
