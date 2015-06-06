using System.Collections.Generic;

namespace Mse.Core
{
   public interface MangaFinder
   {
      MangaFinderVersion Version { get; }
      IEnumerable<MangaFinderItem> Find(string pSearchToken);
   }
}