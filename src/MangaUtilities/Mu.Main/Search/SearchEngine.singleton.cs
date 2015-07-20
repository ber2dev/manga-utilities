namespace Mu.Main.Search
{
    public partial class SearchEngine
    {
        public static readonly object SINGLETON_LOCK = new object();

        private volatile static SearchEngine _instance;

        public static SearchEngine Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SINGLETON_LOCK)
                    {
                        if (_instance == null)
                        {
                            _instance = new SearchEngine();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
