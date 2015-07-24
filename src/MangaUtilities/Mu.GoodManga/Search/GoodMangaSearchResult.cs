using Mu.Core.Search;

namespace Mu.GoodManga.Search
{
    public class GoodMangaSearchResult : ISearchResult
    {
        public MangaInformation MangaInformation { get; set; }
        public ChapterInformation ChapterInformation { get; set; }
    }
}