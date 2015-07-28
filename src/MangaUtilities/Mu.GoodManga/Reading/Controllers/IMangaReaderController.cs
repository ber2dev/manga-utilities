using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.GoodManga.Reading.Controllers
{
    public interface IMangaReaderController : IController
    {
        void CreateChapterReader(IManager pManager);
    }
}
