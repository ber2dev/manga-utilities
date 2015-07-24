using System;
using Mu.Core.Search;

namespace Mu.GoodManga.Search
{
    public class GoodMangaGetPageTask : GetPageTaskBase
    {
        private readonly MangaInformation _mangaInformation;
        private readonly ChapterInformation _chapterInformation;
        private readonly int _page;

        private string _imagePath;

        public GoodMangaGetPageTask(
            MangaInformation pMangaInformation,
            ChapterInformation pChapterInformation,
            int pPage)
        {
            _mangaInformation = pMangaInformation;
            _chapterInformation = pChapterInformation;
            _page = pPage;
        }

        public override void Do()
        {
            _imagePath = "";
        }

        public override object GetResult()
        {
            return new GoodMangaGetPageResult
            {
                Filepath = _imagePath
            };
        }
    }
}
