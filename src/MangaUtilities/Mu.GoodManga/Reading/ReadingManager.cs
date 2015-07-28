using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Reading
{
    public class ReadingManager : ManagerBase
    {
        public ReadingManager(IManager pParent)
            : base(pParent)
        {
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (!CanExecute(pAction))
            {
                return GetCannotExecuteActionResult(pAction);
            }

            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }
            
            if (pAction is StartReadAction)
            {
                return ExecuteToChildren(pAction);
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
