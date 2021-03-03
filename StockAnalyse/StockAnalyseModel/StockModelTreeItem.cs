using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseModel
{
    public class StockModelTreeItem : BindableBase
    {
        private Stock_List _StockModel;
        public Stock_List StockModel
        {
            get
            {
                return _StockModel;
            }
            set
            {
                SetProperty(ref _StockModel, value);
            }
        }
        private bool _IsExpanded;
        public bool IsExpanded
        {
            get
            {
                return _IsExpanded;
            }
            set
            {
                SetProperty(ref _IsExpanded, value);
            }
        }
        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                SetProperty(ref _IsSelected, value);
            }
        }
    }
}
