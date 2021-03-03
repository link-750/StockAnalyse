using LiveCharts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using StockAnalyseModel;
using StockAnalyseApiHelper.Helper;
using StockAnalyseApiHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StockAnalyseEvent;
using StockAnalyseCommonClass;
namespace ModuleStockNavigate.ViewModel
{  
    class NavigatebarViewModel : BindableBase
    {

        private IContainerExtension containerExtension;
        private IRegionManager regionManager;
        public NavigatebarViewModel(IEventAggregator eventAggregator, IContainerExtension container, IRegionManager regionManager)
        {
            Event = eventAggregator;
            containerExtension = container;
            this.regionManager = regionManager;
            InitialCommad();
            InitialData();
        }
        #region command

        public DelegateCommand<string> StockTypeSelectItemChangedDelegateCommand { get; private set; }

        public DelegateCommand<string> StockSearchDelegateCommand { get; private set; }

        public DelegateCommand<string> StockTextChangedDelegateCommad { get; private set; }

        public DelegateCommand WindowLoadedDelegateCommad { get; private set; }
        public DelegateCommand<object> TreeItemSelectedIChangedCommand { get; private set; }
        public DelegateCommand<StockModelTreeItem> SendMessageCommand { get; private set; }
        /// <summary>
        /// 添加到自选清单
        /// </summary>
        public DelegateCommand<StockModelTreeItem> AddToSelfSelectListCommand { get; private set; }
        /// <summary>
        /// 添加到黑名单
        /// </summary>
        public DelegateCommand<StockModelTreeItem> AddToBlackListCommand { get; private set; }

        #endregion
        #region Method
        private void InitialCommad()
        {
            StockTypeSelectItemChangedDelegateCommand = new DelegateCommand<string>(StockTypeSelectItemChanged, CanExcute);
            StockSearchDelegateCommand = new DelegateCommand<string>(StockSearch, CanExcute);
            StockTextChangedDelegateCommad = new DelegateCommand<string>(StockTypeSelectItemChanged, CanExcute);
            TreeItemSelectedIChangedCommand = new DelegateCommand<object>(TreeItemSelectedIChanged, CanExcute);
            SendMessageCommand = new DelegateCommand<StockModelTreeItem>(SendMessage);
            AddToSelfSelectListCommand = new DelegateCommand<StockModelTreeItem>(AddToSelfSelectList);
            AddToBlackListCommand = new DelegateCommand<StockModelTreeItem>(AddToBlackList);
        }
        private void InitialData()
        {
            ConstructStockShowType();
        }
        private void ConstructStockShowType()
        {
            try
            {
                using (var context = new StockAnalyseEntities())
                {
                    List<Stock_Status> StockStatusCol = context.Stock_Status.Where(p => p.id >= 1).Select(p => p).ToList();
                    StockTypeCollection = new ObservableCollection<Stock_Status>(StockStatusCol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //  throw;
            }

        }

        /// <summary>
        /// 从tushare拉取所有股票信息
        /// </summary>
        /// <returns></returns>
        private async Task FetchAllStockList()
        {

            try
            {
                WebManager webManager = new WebManager();
                Dictionary<string, string> Paramas = new Dictionary<string, string>();
                Paramas.Add("list_status", "L");
                string StockInfor = await webManager.GetStockInfo(StocksType.stock_basic, Paramas);
                await Task.Run(() => {
                    JObject jObject = (JObject)JsonConvert.DeserializeObject(StockInfor);
                    List<JToken> FieldList = jObject["data"]["fields"].ToList();
                    List<JToken> ItemsList = jObject["data"]["items"].ToList();
                    List<Stock_List> stock_Lists = new List<Stock_List>();
                    for (int itemindex = 0; itemindex < ItemsList.Count; itemindex++)
                    {
                        Stock_List stock_List = new Stock_List();
                        for (int fieldindex = 0; fieldindex < FieldList.Count; fieldindex++)
                        {
                            PropertyInfo prop = stock_List.GetType().GetProperty(FieldList[fieldindex].ToString(), BindingFlags.Public | BindingFlags.Instance);
                            if (null != prop && prop.CanWrite)
                            {
                                prop.SetValue(stock_List, ItemsList[itemindex][fieldindex].ToString(), null);
                            }
                        }
                        stock_Lists.Add(stock_List);
                    }
                    using (var DBStockAnalyseEntities = new StockAnalyseEntities())
                    {
                        DBStockAnalyseEntities.Stock_List.AddRange(stock_Lists);
                        DBStockAnalyseEntities.SaveChanges();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // throw;
            }

        }
        private void StockTypeSelectItemChanged(string StockType)
        {
            StockModelCollection.Clear();
            GetStockList(StockType);

        }
        private async Task GetStockList(string StockType)
        {
            await Task.Run(() =>
            {
                List<StockModelTreeItem> TempStockModelCollection = new List<StockModelTreeItem>();
                try
                {

                    using (var context = new StockAnalyseEntities())
                    {
                        List<Stock_List> stockModelTreeItem = context.Stock_List.Where(p => p.Stock_Status == StockType).Select(p => p).ToList();
                        foreach (var StockListitem in stockModelTreeItem)
                        {
                            StockModelTreeItem MdlTreeItem = new StockModelTreeItem();
                            MdlTreeItem.StockModel = StockListitem;
                            TempStockModelCollection.Add(MdlTreeItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { StockModelCollection.AddRange(TempStockModelCollection); }));

            });
        }
        int PageInx = 0;
        private void StockSearch(string SearchText)
        {
            //PageInx++;
            //containerExtension.RegisterForNavigation<StockContentViewBase, StockContentViewModelBase>(name: "FirstWindow"+ PageInx);
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(StockContentViewBase));
        }
        private void StockTextChanged(string Text)
        {

        }
        private void TreeItemSelectedIChanged(object SelectedItem)
        {
            try
            {
                StockModelTreeItem SelectedStockModel = SelectedItem as StockModelTreeItem;
                if (SelectedStockModel != null)
                {
                    SendMessageCommand.Execute(SelectedStockModel);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());

            }
        }

        private bool CanExcute(object Param)
        {
            return true;
        }



        private void SendMessage(StockModelTreeItem stockModelTreeItem)
        {
            //Event.GetEvent<StockModelEventMessage>().Publish(stockModelTreeItem);
            var Param = new NavigationParameters();
            Param.Add("SelectTreeItem", stockModelTreeItem);
            if (stockModelTreeItem != null)
            {
                regionManager.RequestNavigate("ContentRegion", "Content", Param);
            }
           
        }

        private async void AddToSelfSelectList(StockModelTreeItem stockModelTreeItem)
        {
            await Task.Run(() =>
            {

                try
                {

                    using (var context = new StockAnalyseEntities())
                    {
                        stockModelTreeItem.StockModel.Stock_Status = "1";
                        context.Entry<Stock_List>(stockModelTreeItem.StockModel).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }
        private async void AddToBlackList(StockModelTreeItem stockModelTreeItem)
        {
            await Task.Run(() =>
            {

                try
                {

                    using (var context = new StockAnalyseEntities())
                    {
                        stockModelTreeItem.StockModel.Stock_Status = "2";
                        context.Entry<Stock_List>(stockModelTreeItem.StockModel).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }

        #endregion
        #region property


        private ObservableRangeCollection<StockModelTreeItem> _StockModelCollection = new ObservableRangeCollection<StockModelTreeItem>();
        private ObservableCollection<Stock_Status> _StockTypeCollection = new ObservableCollection<Stock_Status>();

        public ObservableRangeCollection<StockModelTreeItem> StockModelCollection
        {
            get
            {
                return _StockModelCollection;
            }
            set
            {
                _StockModelCollection = value;
                //bool ii= SetProperty(ref _StockModelCollection, value, "StockModelCollection");
                // RaisePropertyChanged("StockModelCollection");
            }
        }
        public ObservableCollection<Stock_Status> StockTypeCollection { get => _StockTypeCollection; set => _StockTypeCollection = value; }
        IEventAggregator Event;
        #endregion
    }
}
