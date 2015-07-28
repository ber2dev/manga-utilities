using Mu.Client.Infrastructure.Actions;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Actions
{
    public class ReadMangaAction : ActionBase
    {
        public const string MANGA_INFORMATION_PARAMETER = "MANGA_INFORMATION";
        public const string CHAPTER_INFORMATION_PARAMETER = "CHAPTER_INFORMATION";

        public ReadMangaAction(object pSource)
            : this(pSource, null, null)
        {
        }

        public ReadMangaAction(object pSource, MangaInformation pManga, ChapterInformation pChapter)
            : base(pSource)
        {
            Manga = pManga;
            Chapter = pChapter;
        }

        public MangaInformation Manga
        {
            get { return GetParameter<MangaInformation>(MANGA_INFORMATION_PARAMETER); }
            set { SetParameter(MANGA_INFORMATION_PARAMETER, value); }
        }

        public ChapterInformation Chapter
        {
            get { return GetParameter<ChapterInformation>(CHAPTER_INFORMATION_PARAMETER); }
            set { SetParameter(CHAPTER_INFORMATION_PARAMETER, value); }
        }
    }
}