using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseApiHelper.Model
{
    class StockPara
    {
        

           // public StockType stockType { get; set; }

            public string api_name { get; set; }

            public string token { get; set; }

            public Dictionary<string, string> Params { get; set; }

            public string Fields { get; set; }

      
    }
}
