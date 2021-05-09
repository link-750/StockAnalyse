using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicControlLibrary.LineChart
{
    class DataModel
    {
        public int? id { get; set; }
        public string ts_code { get; set; }
        public string trade_date { get; set; }
        public Nullable<double> open { get; set; }
        public Nullable<double> high { get; set; }
        public Nullable<double> low { get; set; }
        public Nullable<double> close { get; set; }
        public Nullable<double> pre_close { get; set; }
        public Nullable<double> change { get; set; }
        public Nullable<double> pct_chg { get; set; }
        public Nullable<double> vol { get; set; }
        public Nullable<double> amount { get; set; }
    }
}
