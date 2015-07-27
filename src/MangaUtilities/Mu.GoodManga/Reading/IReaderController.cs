using Mu.Client.Infrastructure.Components;
using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.GoodManga.Reading
{
    public interface IReaderController : IController
    {
        void CreateReader(IManager pManager);
    }
}
