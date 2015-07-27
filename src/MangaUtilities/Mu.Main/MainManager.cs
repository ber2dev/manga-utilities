using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Core.Common.Validation;

namespace Mu.Main
{
    public class MainManager : ManagerBase
    {
        public MainManager(IManager pParent)
            : base(pParent)
        {
        }

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
