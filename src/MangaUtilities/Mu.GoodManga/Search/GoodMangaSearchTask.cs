using Mu.Core.Search;

namespace Mu.GoodManga.Search
{
    public class GoodMangaSearchTask : SearchTaskBase
    {
        private GoodMangaSearchResult _result;

        public override void Do()
        {
            _result = new GoodMangaSearchResult
            {
                MangaInformation = new MangaInformation
                {
                    Sid = "naruto"
                }
            };
        }

        public override object GetResult()
        {
            return _result;
        }
    }
}
