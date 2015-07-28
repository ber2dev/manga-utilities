using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Reading.Controllers
{
    public interface IReaderController : IController
    {
        void CreateReader(IManager pManager);
    }
}
