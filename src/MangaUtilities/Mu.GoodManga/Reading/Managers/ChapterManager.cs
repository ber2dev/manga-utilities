using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components.Managers;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Reading.Managers
{
    public class ChapterManager : ManagerBase
    {
        private readonly ChapterInformation _chapterToRead;

        public ChapterManager(IManager pParent, ChapterInformation pChapterToRead)
            : base(pParent)
        {
            _chapterToRead = pChapterToRead;
        }

        public ChapterInformation Chapter
        {
            get { return _chapterToRead; } 
        }

        public override IActionResult Execute(object pSouce, IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pSouce, pAction);
        }
    }
}
