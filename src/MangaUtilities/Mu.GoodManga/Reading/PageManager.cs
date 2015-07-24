﻿using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;

namespace Mu.GoodManga.Reading
{
    public class PageManager : ComponentBase
    {
        public PageManager(IComponent pParent)
            : base(pParent)
        {
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            return base.Execute(pAction);
        }
    }
}
