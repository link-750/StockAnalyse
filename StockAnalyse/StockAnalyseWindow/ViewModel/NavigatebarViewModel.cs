using LiveCharts;
using Prism.Commands;
using Prism.Mvvm;
using StockAnalyseWindow.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockAnalyseWindow.ViewModel
{
    class NavigatebarViewModel : BindableBase
    {
        public NavigatebarViewModel()
        {
            StockTypeCollection.Add(new StockType() { StockTypeStr="自选股"});
            StockTypeCollection.Add(new StockType() { StockTypeStr = "所有股" });
            InitialCommad();
        }
        #region command
     
        public DelegateCommand<string> StockTypeSelectItemChangedDelegateCommand { get; private set; }

        public DelegateCommand<string> StockSearchDelegateCommand { get; private set; }

        public DelegateCommand<string> StockTextChangedDelegateCommad { get; private set; }

        public DelegateCommand WindowLoadedDelegateCommad { get; private set; }
        #endregion
        #region Method
        private void InitialCommad()
        {
            StockTypeSelectItemChangedDelegateCommand = new DelegateCommand<string>(StockTypeSelectItemChanged, CanExcute);
            StockSearchDelegateCommand = new DelegateCommand<string>(StockTypeSelectItemChanged, CanExcute);
            StockTextChangedDelegateCommad =new DelegateCommand<string>(StockTypeSelectItemChanged, CanExcute);

        }
        private void StockTypeSelectItemChanged(string StockType)
        {
            MessageBox.Show("123");
        }
        private void StockSearch(string SearchText)
        {
            MessageBox.Show("123");
        }
        private void StockTextChanged(string Text)
        {
            MessageBox.Show("123");
        }
        private bool CanExcute(string Param)
        {
            return true;
        }

        #endregion
        private ObservableCollection<StockModelTreeItem> _StockModelCollection = new ObservableCollection<StockModelTreeItem>();
        private ObservableCollection<StockType> _StockTypeCollection = new ObservableCollection<StockType>();

        public ObservableCollection<StockModelTreeItem> StockModelCollection { get => _StockModelCollection; set => _StockModelCollection = value; }
        public ObservableCollection<StockType> StockTypeCollection { get => _StockTypeCollection; set => _StockTypeCollection = value; }
    }
}
