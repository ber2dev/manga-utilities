using System;

namespace Mu.Client.Infrastructure
{
    public interface INavigationContext
    {
        Type GetViewType();
    }
}