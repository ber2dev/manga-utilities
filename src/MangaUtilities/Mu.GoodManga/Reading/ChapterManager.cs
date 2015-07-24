using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading
{
    public class ChapterManager : ComponentBase
    {
        public ChapterManager(IComponent pParent)
            : base(pParent)
        {
        }

        public ChapterInformation Chapter { get; set; }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pAction);
        }
    }
}
