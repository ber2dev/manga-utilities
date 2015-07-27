using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Reading
{
    public interface IReaderController : IController
    {
        void CreateReader(IManager pManager);
    }
}
