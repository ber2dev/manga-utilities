using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;
using Mu.Core.Common.Service.Async;
using Mu.Core.Common.Tasking;
using Mu.Core.Search;
using Mu.Main.Search;

namespace Mu.GoodManga.Search
{
    public class GoodMangaSearchService : AsyncServiceBase, ISearchService, IObservable<ISearchResult>
    {
        private readonly IList<IObserver<ISearchResult>> _searchObserverList;
        private readonly Thread _creationThread;

        public GoodMangaSearchService()
            :base(typeof(GoodMangaSearchService).Name)
        {
            _searchObserverList = new List<IObserver<ISearchResult>>();
            _creationThread = Thread.CurrentThread;
        }

        public IDisposable Subscribe(IObserver<ISearchResult> pObserver)
        {
            SearchObserverList.Add(pObserver);
            return null;
        }

        public void Search(SearchParameters pSearchParameters)
        {
            TaskCollection.Enqueue(new GoodMangaSearchTask());
        }

        protected IList<IObserver<ISearchResult>> SearchObserverList
        {
            get
            {
                lock (_searchObserverList)
                {
                    return _searchObserverList;
                }
            }
        }

        protected override void OnTaskDone(ITask pTask)
        {
            Notify(pTask.GetResult());
        }

        private void Notify(object pResult)
        {
            var searchResult = pResult as ISearchResult;
            foreach (var searchObserver in SearchObserverList)
            {
                var observer = searchObserver;
                var fromThread = Dispatcher.FromThread(_creationThread);
                if (fromThread != null)
                {
                    fromThread.Invoke(() => observer.OnNext(searchResult));
                }
                else
                {
                    observer.OnNext(searchResult);
                }
            }
        }
    }
}
