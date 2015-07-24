﻿using System.Linq;
using Mu.Client.Infrastructure.Actions;
using Mu.Client.Infrastructure.Components;
using Mu.GoodManga.Reading;

namespace Mu.GoodManga
{
    public class GoodMangaManager : ComponentBase
    {
        public GoodMangaManager(IComponent pParentManager)
            : base(pParentManager)
        {
        }

        public override IActionResult Execute(IAction pAction)
        {
            if (pAction is LoadAction)
            {
                return ExecuteToChildren(new LoadAction(this));
            }

            if (pAction is ReadMangaAction)
            {
                return ExecuteToChildren(pAction);
            }

            return base.Execute(pAction);
        }
    }
}
