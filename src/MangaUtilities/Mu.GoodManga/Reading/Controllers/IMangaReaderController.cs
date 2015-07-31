using Mu.Client.Infrastructure.Components.Controllers;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Controllers
{
    public interface IMangaReaderController : IController
    {
        void CreateChapterReader(IManager pManager);
        void SelectChapter(ChapterInformation pChapter);
        void AddChapter(ChapterInformation pChapter);
    }
}
