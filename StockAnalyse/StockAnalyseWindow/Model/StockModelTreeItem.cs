using StockAnalyseWindow.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseWindow.Model
{
    class StockModelTreeItem: BindableBase
    {
        private Stock_List _StockModel;
        public Stock_List StockModel
        {
            get {
                 return _StockModel;
            }
            set
            {
                SetProperty(ref _StockModel, value);
            }
        }
        private bool _IsExpand;
        public bool IsExpand {
            get
            {
                return _IsExpand;
            }
            set
            {
                SetProperty(ref _IsExpand, value);
            }
        }
    }
}
