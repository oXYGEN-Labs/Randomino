using Randomizer.Core;
using Randomizer.Modules.SimpleRandom;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Randomizer.Modules.SimpleRandom
{
    public class SimpleRandomModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SimpleRandomModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "BasicRandom");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BasicRandom>();
        }
    }
}