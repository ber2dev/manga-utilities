using System;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.Core.Search;
using Mu.GoodManga.Actions;
using Mu.Main.Search;

namespace Mu.GoodManga.Search
{
    public class SearchManager : ManagerBase, ISearchObserver
    {
        private readonly GoodMangaSearchService _searchService;

        public SearchManager(IManager pParentManager)
            : base(pParentManager)
        {
            _searchService = new GoodMangaSearchService();
            _searchService.Subscribe(this);
            SearchEngine.Instance.Register(_searchService);
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                _searchService.Start();
                return ExecuteToChildren(new LoadAction(this));
            }
            else if (pAction is WebSearchAction)
            {
                _searchService.Search(
                    new SearchParameters(((WebSearchAction)pAction).GetParameter<string>("SearchKey")));
            }

            return base.Execute(pAction);
        }

        public void OnNext(ISearchResult pValue)
        {
            GetController<ISearchController>().AddManga(((GoodMangaSearchResult) pValue).MangaInformation);
        }

        public void OnError(Exception pError)
        {
        }

        public void OnCompleted()
        {

        }
    }
}
