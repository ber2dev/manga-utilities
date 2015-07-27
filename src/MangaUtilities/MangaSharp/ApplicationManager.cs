using System.Windows;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Components;

namespace MangaSharp
{
    public class ApplicationManager : ManagerBase
    {
        private readonly Application _current;

        public ApplicationManager(Application pCurrent)
        {
            _current = pCurrent;
        }
    }
}
