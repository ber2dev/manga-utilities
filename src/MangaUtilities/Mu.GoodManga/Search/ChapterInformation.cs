namespace Mu.GoodManga.Search
{
    public class ChapterInformation
    {
        public static readonly ChapterInformation DEFAULT = new ChapterInformation
        {
            Number = 1,
            NumberOfPages = -1
        };

        public int Number { get; set; }
        public int NumberOfPages { get; set; }
    }
}