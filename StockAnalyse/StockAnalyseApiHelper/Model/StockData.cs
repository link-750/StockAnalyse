using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseApiHelper.Model
{
    /// <summary>
    /// 具体的股票数据，根据获取的类型不同，fields，items的数据不一样
    /// </summary>
    public class StockData
    {
        public string[] fields { get; set; }
        public string[][] items { get; set; }
    }
}
