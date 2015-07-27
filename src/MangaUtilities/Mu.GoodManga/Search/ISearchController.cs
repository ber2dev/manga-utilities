using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.GoodManga.Search
{
    public interface ISearchController : IController
    {
        void AddManga(MangaInformation pManga);
    }
}
