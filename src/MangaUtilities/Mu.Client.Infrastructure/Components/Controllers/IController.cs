﻿using Mu.Client.Infrastructure.Components.Managers;

namespace Mu.Client.Infrastructure.Components.Controllers
{
    public interface IController
    {
        IManager GetManager();
        void SetManager(IManager pManager);
        bool IsManager(IManager pManager);
        void Load(object pState);
    }
}
