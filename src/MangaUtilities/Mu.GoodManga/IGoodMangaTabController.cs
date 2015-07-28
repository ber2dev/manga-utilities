using Mu.Client.Infrastructure.Components.Controllers;

namespace Mu.GoodManga
{
    public interface IGoodMangaTabController : IController
    {
        void ActivateTab(GoodMangaContext pGoodMangaContext);
    }
}
