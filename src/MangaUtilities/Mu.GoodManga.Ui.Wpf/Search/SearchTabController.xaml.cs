﻿using System.Linq;
using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Search;

namespace Mu.GoodManga.Ui.Wpf.Search
{
    /// <summary>
    /// Interaction logic for DownloadTabController.xaml
    /// </summary>
    public partial class SearchTabController
    {
        public SearchTabController(IComponent pParent)
            : base(pParent)
        {
            InitializeComponent();

            var searchManager = new SearchManager(this);
            Content = new SearchController(searchManager);
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                var childrenResults = ComponentUtilities.ExecuteToChildren(this, new LoadAction(this)) ?? new IActionResult[0];
                return new CompositeActionResult(childrenResults.ToArray());
            }

            return base.Execute(pAction);
        }
    }
}