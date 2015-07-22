using System.Linq;
using System.Threading;
using Mu.Core.Common.Tasking;

namespace Mu.Core.Common.Service.Async
{
    public abstract class AsyncServiceBase : ServiceBase, IAsyncService
    {
        private const int SLEEP_TIME = 2000;

        private readonly Thread _thread;
        private readonly TaskCollection _taskCollection;
        private readonly object _propertyLock;

        private bool _isRunning;

        protected AsyncServiceBase()
        {
            _taskCollection = new TaskCollection();
            _propertyLock = new object();
            _thread = new Thread(ThreadCore);
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            IsRunning = false;
        }

        protected bool IsRunning
        {
            get
            {
                lock (_propertyLock)
                {
                    return _isRunning;
                }
            }

            set
            {
                lock (_propertyLock)
                {
                    _isRunning = value;
                }
            }
        }

        protected bool HasTask
        {
            get
            {
                lock (TaskCollection)
                {
                    return TaskCollection.Any();
                }
            }
        }

        protected TaskCollection TaskCollection
        {
            get { return _taskCollection; }
        }

        protected virtual void OnTaskDone(ITask pTask)
        {
        }

        private void ThreadCore()
        {
            IsRunning = true;
            while (IsRunning)
            {
                if (!HasTask)
                {
                    continue;
                }

                var task = TaskCollection.Dequeue();
                task.Do();
                OnTaskDone(task);

                Thread.Sleep(SLEEP_TIME);
            }
        }
    }
}
