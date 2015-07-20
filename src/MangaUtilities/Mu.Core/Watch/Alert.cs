namespace Mu.Core.Watch
{
    public sealed class Alert
    {
        public Alert(IAlertMetadata pMetadata)
        {
            Metadata = pMetadata;
        }

        public IAlertMetadata Metadata
        {
            get; 
            private set;
        }

    }
}
