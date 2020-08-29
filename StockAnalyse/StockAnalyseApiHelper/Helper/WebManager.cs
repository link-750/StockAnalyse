
using Newtonsoft.Json;
using StockAnalyseApiHelper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyseApiHelper.Helper
{
    public  class WebManager
    {
        static string url = "http://api.waditu.com ";
        static string Token = "dd6b9ed51e7ba757dafbd1398fb8dae5bcbf92507032be9d414b83ba";
        public string GetStockInfo(StockType stockType, Dictionary<string, string> sparams, string fields = "")
        {
            StockPara para = new StockPara();
            para.api_name = stockType.ToString();
            para.sparams = sparams;
            para.token = Token;
            para.fields = fields;
            var JsonStr = JsonConvert.SerializeObject(para);      

            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(JsonStr);//把字符串转换为字节
            req.ContentLength = data.Length; //请求长度
            using (Stream reqStream = req.GetRequestStream()) //获取
            {
                reqStream.Write(data, 0, data.Length);//向当前流中写入字节
                reqStream.Close(); //关闭当前流
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //响应结果
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
            
        }

    }
}
