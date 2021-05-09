using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace StockAnalyseWindow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

       
        public MainWindow()
        {
            InitializeComponent();
            //this.Loaded += (s,e)=> { ConstructRegion(); };

        }      
        public MainWindow(IContainerExtension container, IRegionManager regionManager) : this()
        {
            _container = container;
            _regionManager = regionManager;
        }
        private void ConstructRegion()
        {
            //var ContentView = _container.Resolve<Content>();
            //var MenubarView = _container.Resolve<Menubar>();
            //var ToolBarView = _container.Resolve<Views.ToolBar>();
            //var NavigatebarView = _container.Resolve<Navigatebar>();
            //var StatusbarView = _container.Resolve<Statusbar>();
            //IRegion region = _regionManager.Regions["MenubarRegion"];
            //region.Add(MenubarView);
            //region = _regionManager.Regions["ContentRegion"];
            //region.Add(ContentView);
            //region = _regionManager.Regions["ToolbarRegion"];
            //region.Add(ToolBarView);
            //region = _regionManager.Regions["NavigateRegion"];
            //region.Add(NavigatebarView);
            //region = _regionManager.Regions["StatusbarRegion"];
            //region.Add(StatusbarView);
        }
        
    }
}
