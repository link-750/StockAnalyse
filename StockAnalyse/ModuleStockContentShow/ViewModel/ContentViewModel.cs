using LiveCharts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using StockAnalyseApiHelper.Helper;
using StockAnalyseApiHelper.Model;
using StockAnalyseEvent;
using StockAnalyseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModuleStockContentShow.ViewModel
{
    class ContentViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {

        public ContentViewModel(IEventAggregator eventAggregator,IRegionManager regionManager)
        {
            EventAggregator = eventAggregator;
            RegionManager = regionManager;
            InitData();
        }

        #region Method
        private void InitData()
        {
            EventAggregator.GetEvent<StockModelEventMessage>().Subscribe(MessageReceived);
            YFormatterLine = value => value.ToString("f3");           
            CloseTabPageCmd = new DelegateCommand<object>(CloseTabPage);
        }
        private void CloseTabPage(object tabItem)
        {
            KeepAlive = false;            
            RegionManager.Regions["ContentRegion"].Remove(tabItem);           
            
        }
       
        private void MessageReceived(StockModelTreeItem stockModelEventMessage)
        {
            if (stockModelEventMessage != null)
            {
                GetStockData(stockModelEventMessage.StockModel.ts_code);
            }
        }
        private async void GetStockData(string StockCode)
        {
            try
            {
                List<Stock_Transaction_Records> RecordesList = new List<Stock_Transaction_Records>();
                RecordesList = await Task.Run(() =>
                {
                    List<Stock_Transaction_Records> TempRecordesList = new List<Stock_Transaction_Records>();
                    using (var context = new StockAnalyseEntities())
                    {

                        TempRecordesList = context.Stock_Transaction_Records.Where(p => p.ts_code == StockCode).Select(p => p).OrderByDescending(p => p.trade_date).Take(100).OrderBy(p => p.trade_date).ToList();
                    }
                    return TempRecordesList;
                });
                if (RecordesList == null || RecordesList.Count <= 0)
                {
                    await GetWebStockDailyOperationRecord(StockCode);//如果数据库为空到web中取数据
                    GetStockData(StockCode);
                }
                ConstructLineData(RecordesList);             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ConstructLineData(List<Stock_Transaction_Records> LineDataList)
        {
            OpenPrice = new ChartValues<double>();
            ClosePrice = new ChartValues<double>();
            HighPrice = new ChartValues<double>();
            LowPrice = new ChartValues<double>();
            List<string> TimeArr = new List<string>();
            for (int i = 0; i < LineDataList.Count; i++)
            {
                OpenPrice.Add((double)LineDataList[i]?.open);
                ClosePrice.Add((double)LineDataList[i]?.close);
                HighPrice.Add((double)LineDataList[i]?.high);
                LowPrice.Add((double)LineDataList[i]?.low);
                TimeArr.Add((string)LineDataList[i]?.trade_date);
            }
            XTimeLabels = TimeArr.ToArray();
        }
        /// <summary>
        /// 获取某只股票的日线行情信息
        /// </summary>
        private async Task GetWebStockDailyOperationRecord(string StockTsCode)
        {
            try
            {
                WebManager webManager = new WebManager();
                Dictionary<string, string> Paramas = new Dictionary<string, string>();
                Paramas.Add("ts_code", StockTsCode);
                Paramas.Add("start_date", DateTime.Now.AddDays(-7300).ToString("yyyyMMdd"));
                Paramas.Add("end_date", DateTime.Now.ToString("yyyyMMdd"));
                string StockInfor = await webManager.GetStockInfo(StocksType.daily, Paramas);
                await Task.Run(() =>
                {
                    JObject jObject = (JObject)JsonConvert.DeserializeObject(StockInfor);
                    List<JToken> FieldList = jObject["data"]["fields"].ToList();
                    List<JToken> ItemsList = jObject["data"]["items"].ToList();
                    List<Stock_Transaction_Records> StockTransactionRecordsLists = new List<Stock_Transaction_Records>();
                    for (int itemindex = 0; itemindex < ItemsList.Count; itemindex++)
                    {
                        Stock_Transaction_Records stockTransactionRecords = new Stock_Transaction_Records();
                        for (int fieldindex = 0; fieldindex < FieldList.Count; fieldindex++)
                        {
                            PropertyInfo prop = stockTransactionRecords.GetType().GetProperty(FieldList[fieldindex].ToString(), BindingFlags.Public | BindingFlags.Instance);
                            if (null != prop && prop.CanWrite)
                            {
                                if (prop.PropertyType == typeof(string))
                                {
                                    prop.SetValue(stockTransactionRecords, ItemsList[itemindex][fieldindex].ToString(), null);
                                }
                                else
                                {
                                    prop.SetValue(stockTransactionRecords, Convert.ToDouble(ItemsList[itemindex][fieldindex].ToString()), null);
                                }
                            }
                        }
                        StockTransactionRecordsLists.Add(stockTransactionRecords);
                    }
                    using (var DBStockAnalyseEntities = new StockAnalyseEntities())
                    {
                        DBStockAnalyseEntities.Stock_Transaction_Records.AddRange(StockTransactionRecordsLists);
                        DBStockAnalyseEntities.SaveChanges();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _Journal = navigationContext.NavigationService.Journal;
            var stockModelTreeItem = navigationContext.Parameters["SelectTreeItem"] as StockModelTreeItem;
            if (stockModelTreeItem != null)
            {
                SelectedstockModelTreeItem = stockModelTreeItem;
                Title = SelectedstockModelTreeItem.StockModel.name;
                MessageReceived(SelectedstockModelTreeItem);
            }
               
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var stockModelTreeItem = navigationContext.Parameters["SelectTreeItem"] as StockModelTreeItem;
            if (stockModelTreeItem != null)
                return SelectedstockModelTreeItem != null && SelectedstockModelTreeItem.StockModel.name == stockModelTreeItem.StockModel.name;
            else
                return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }
        #endregion
        #region 属性字段

        IEventAggregator EventAggregator;
        IRegionManager RegionManager;
        private ObservableCollection<Stock_Transaction_Records> _StockModelCollection = new ObservableCollection<Stock_Transaction_Records>();
        public ObservableCollection<Stock_Transaction_Records> StockModelCollection
        {
            get
            {
                return _StockModelCollection;
            }
            set
            {
                _StockModelCollection = value;
                RaisePropertyChanged("StockModelCollection");
            }
        }
        /// <summary>
        /// 纵坐标显示
        /// </summary>
        public Func<double, string> _yFormatterLine { get; set; }
        public Func<double, string> YFormatterLine
        {
            get => _yFormatterLine;
            set
            {
                _yFormatterLine = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 横坐标显示
        /// </summary>
        private string[] _xTimeLabels = new string[] { };
        public string[] XTimeLabels
        {
            get
            {
                return _xTimeLabels;
            }
            set
            {
                _xTimeLabels = value;
                RaisePropertyChanged("XTimeLabels");
            }
        }
        /// <summary>
        /// 开盘价格
        /// </summary>
        private ChartValues<double> _OpenPrice;
        public ChartValues<double> OpenPrice
        {
            get { return _OpenPrice; }
            set
            {
                _OpenPrice = value;
                RaisePropertyChanged("OpenPrice");
            }
        }
        /// <summary>
        /// 收盘价格
        /// </summary>
        private ChartValues<double> _ClosePrice;
        public ChartValues<double> ClosePrice
        {
            get { return _ClosePrice; }
            set
            {
                _ClosePrice = value;
                RaisePropertyChanged("ClosePrice");
            }
        }
        /// <summary>
        /// 最高价格
        /// </summary>
        private ChartValues<double> _HighPrice;
        public ChartValues<double> HighPrice
        {
            get { return _HighPrice; }
            set
            {
                _HighPrice = value;
                RaisePropertyChanged("HighPrice");
            }
        }
        /// <summary>
        /// 收盘价格
        /// </summary>
        private ChartValues<double> _LowPrice;
        public ChartValues<double> LowPrice
        {
            get { return _LowPrice; }
            set
            {
                _LowPrice = value;
                RaisePropertyChanged("LowPrice");
            }
        }
        private StockModelTreeItem _SelectedstockModelTreeItem;
        public StockModelTreeItem SelectedstockModelTreeItem
        {
            get { return _SelectedstockModelTreeItem; }
            set { SetProperty(ref _SelectedstockModelTreeItem, value); }
        }

        private string _Title = "Welcome";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        //public DelegateCommand<DependencyObject> CloseTabPageCmd { get; private set; }
        public DelegateCommand<object> CloseTabPageCmd { get; private set; }
        private bool _KeepAlive = true;
        public bool KeepAlive
        {
            get
            {
                return _KeepAlive;
            }
            set {
                _KeepAlive = value;
              }
        }
        IRegionNavigationJournal _Journal;
        #endregion

    }
}
