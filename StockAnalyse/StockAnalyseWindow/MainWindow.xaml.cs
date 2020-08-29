using Prism.Regions;
using StockAnalyseWindow.Views;
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
        private IRegionManager regionManager;
        private IContainer container;
        public MainWindow()
        {
            InitializeComponent();

        }
        public MainWindow(IRegionManager RegionManager):this()
        {
           
            regionManager = RegionManager;                      
            InitMainShell();
        }
        private void InitMainShell()
        {
            regionManager.RegisterViewWithRegion("MenubarRegion",typeof(Menubar));
            regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(Views.ToolBar));
            regionManager.RegisterViewWithRegion("StatusbarRegion",typeof(Statusbar));
            regionManager.RegisterViewWithRegion("NavigateRegion", typeof(Navigatebar));
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(Content));
        }
    }
}
