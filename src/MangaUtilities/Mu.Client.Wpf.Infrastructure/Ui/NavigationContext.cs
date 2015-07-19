using System;
using Mu.Client.Infrastructure;

namespace Mu.Client.Wpf.Infrastructure.Ui
{
    public class NavigationContext : INavigationContext
    {
        private readonly IAction _action;

        public NavigationContext(IAction action)
        {
            _action = action;
        }

        public Type GetViewType()
        {
            return _action.GetParameter<Type>("View");
        }
    }
}
