using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleStockNavigate
{
    public class ModuleStockNavigateModule : Prism.Modularity.IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<Prism.Regions.IRegionManager>();
            regionManager.RegisterViewWithRegion("NavigateRegion", typeof(Views.Navigatebar));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<>();
        }
    }
}
