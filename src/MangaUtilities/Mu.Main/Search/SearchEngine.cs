using System.Collections.Generic;

namespace Mu.Main.Search
{
    public partial class SearchEngine
    {
        private readonly IList<ISearchService> _searchServices = new List<ISearchService>();

        public void Register(ISearchService pSearchService)
        {
            if (_searchServices.Contains(pSearchService))
            {
                return;
            }

            _searchServices.Add(pSearchService);
        }

        public void Search(SearchParameters pSearchParameters)
        {
            foreach (var searchService in _searchServices)
            {
                searchService.Search(pSearchParameters);
            }
        }
    }
}
