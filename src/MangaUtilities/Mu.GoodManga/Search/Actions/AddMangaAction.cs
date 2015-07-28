using Mu.Client.Infrastructure.Actions;

namespace Mu.GoodManga.Search.Actions
{
    public class AddMangaAction : ActionBase
    {
        public const string MANGA_INFORMATION_PARAMETER = "MANGA_INFORMATION";

        public AddMangaAction(object pSource) 
            : this(pSource, null)
        {
        }

        public AddMangaAction(object pSource, MangaInformation pManga) 
            : base(pSource)
        {
            Manga = pManga;
        }

        public MangaInformation Manga
        {
            get { return GetParameter<MangaInformation>(MANGA_INFORMATION_PARAMETER); }
            set { SetParameter(MANGA_INFORMATION_PARAMETER, value); }
        }
    }
}