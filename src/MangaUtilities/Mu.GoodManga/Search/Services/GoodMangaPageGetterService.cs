using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;
using Mu.Core.Common.Service.Async;
using Mu.Core.Common.Tasking;
using Mu.Core.Search;
using Mu.Main.Search;

namespace Mu.GoodManga.Search.Services
{
    public class GoodMangaPageGetterService: AsyncServiceBase, IPageGetterService, IObservable<IPageGotResult>
    {
        private readonly IList<IObserver<IPageGotResult>> _searchObserverList;
        private readonly Thread _creationThread;

        public GoodMangaPageGetterService()
            : base(typeof(GoodMangaPageGetterService).Name)
        {
            _searchObserverList = new List<IObserver<IPageGotResult>>();
            _creationThread = Thread.CurrentThread;
        }

        public IDisposable Subscribe(IObserver<IPageGotResult> pObserver)
        {
            SearchObserverList.Add(pObserver);
            return null;
        }

        public void GetPage(GetPageParameters pSearchParameters)
        {
            TaskCollection.Enqueue(new GoodMangaSearchTask());
        }

        protected IList<IObserver<IPageGotResult>> SearchObserverList
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
            var searchResult = pResult as IPageGotResult;
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
