using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.GoodManga.Search.Controllers
{
    public interface ISearchController : IController
    {
        void AddManga(MangaInformation pManga);
    }
}
