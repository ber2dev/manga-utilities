namespace Mu.Core.Watch
{
    public sealed class Alert
    {
        public Alert(IAlertMetadata metadata)
        {
            Metadata = metadata;
        }

        public IAlertMetadata Metadata
        {
            get; 
            private set;
        }

    }
}
