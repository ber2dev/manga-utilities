using System.Runtime.InteropServices;
using Mu.Client.Infrastructure;
using Mu.GoodManga.Actions;
using Mu.Main.Search;

namespace Mu.GoodManga.Search
{
    public class SearchManager : ComponentBase
    {
        private readonly GoodMangaSearchService _searchService;

        public SearchManager(IComponent pParentManager)
            : base(pParentManager)
        {
            _searchService = new GoodMangaSearchService();
            SearchEngine.Instance.Register(_searchService);
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is WebSearchAction)
            {
                _searchService.Search(
                    new SearchParameters(((WebSearchAction)pAction).GetParameter<string>("SearchKey")));
            }

            return base.Execute(pAction);
        }
    }
}
