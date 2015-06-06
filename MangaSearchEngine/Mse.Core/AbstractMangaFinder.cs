using System.Collections.Generic;

namespace Mse.Core
{
   public abstract class AbstractMangaFinder : MangaFinder
   {
      private readonly MangaFinderVersion _version;

      protected AbstractMangaFinder(MangaFinderVersion version)
      {
         _version = version;
      }

      public MangaFinderVersion Version
      {
         get { return _version; }
      }

      public abstract IEnumerable<MangaFinderItem> Find(string pSearchToken);
   }
}
