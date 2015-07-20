namespace Mu.Main.Search
{
    public class SearchParameters
    {
        private readonly string _searchKey;

        public SearchParameters(string pSearchKey)
        {
            _searchKey = pSearchKey;
        }

        public string SearchKey
        {
            get { return _searchKey; }
        }
    }
}