using System.Windows;
using Mu.Client.Infrastructure;

namespace MangaSharp
{
    public class ApplicationManager : ComponentBase
    {
        private readonly Application _current;

        public ApplicationManager(Application pCurrent)
        {
            _current = pCurrent;
        }
    }
}
