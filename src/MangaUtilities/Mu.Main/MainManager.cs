using Mu.Client.Infrastructure;

namespace Mu.Main
{
    public class MainManager : ManagerBase
    {
        public MainManager(params IController[] pControllers)
            : base(pControllers)
        {

        }
    }
}
