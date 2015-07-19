using Mu.Client.Infrastructure;

namespace Mu.Main
{
    public interface IContentLoader
    {
        void Load(INavigationContext content);
    }
}
