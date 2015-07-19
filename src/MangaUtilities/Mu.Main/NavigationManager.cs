using System.Collections.Generic;
using Mu.Client.Infrastructure;
using Mu.Client.Wpf.Infrastructure.Ui;
using Mu.Core.Common.Hierarchies;

namespace Mu.Main
{
    public class NavigationManager : ManagerBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly IEnumerable<IController> _controllers;
        private ITree _tree;

        public NavigationManager(
            IContentLoader contentLoader,
            params IController[] controllers)
            :base(controllers)
        {
            _contentLoader = contentLoader;
            _controllers = controllers;
            foreach (var controller in _controllers)
            {
                controller.SetManager(this);
            }
        }

        public void Load(ITree tree)
        {
            _tree = tree;

            foreach (var controller in _controllers)
            {
                controller.UpdateState(_tree);
            }
        }

        public override IActionResult Execute(IAction action)
        {
            if (action is NavigationAction)
            {
                _contentLoader.Load(new NavigationContext(action));
            }

            return null;
        }
    }
}
