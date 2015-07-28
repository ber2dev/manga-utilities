using Mu.Client.Infrastructure.Actions;

namespace Mu.GoodManga.Reading.Managers
{
    public class ReadAction : ActionBase
    {
        private readonly int _startingPage;

        public ReadAction(int pStartingPage) 
            : base(null)
        {
            _startingPage = pStartingPage;
        }

        public int StartingPage
        {
            get { return _startingPage; }
        }
    }
}