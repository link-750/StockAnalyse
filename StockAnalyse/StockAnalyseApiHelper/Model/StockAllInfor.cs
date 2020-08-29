using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseApiHelper.Model
{
    class StockAllInfor
    {
        public string request_id { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public StockData data
        {
            get; set;
        }
    }
}
