using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PublicControlLibrary.LineChart
{
    /// <summary>
    /// LineChart1.xaml 的交互逻辑
    /// </summary>
    public partial class LineChart : UserControl
    {
        public LineChart()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    Candle candle = new Candle();

            //    chartCanvas.Children.Add(candle);
            //    chartCanvas
            //}
            //double TickLength = this.chartCanvas.ActualHeight / 17;
            //for (int i = 2; i < 20; i++)
            //{

            //    string location= "M0.5,31.079 L56.632,31.079 L56.632,130.079 L0.5,130.079 z M29.044005,0.50000004 L29.566993,31.078997 M28.567005,130.579 L28.567005,158.7";
            //    Candle candle = new Candle(location);
            //    this.chartCanvas.Children.Add(candle);
            //    //  this.chartCanvas.Children.Add(XPolyline);
            //}
            double ActureWidth = 500; //this.chartCanvas.ActualWidth;
            double ActureHight = 500;// this.chartCanvas.ActualHeight;
            //double AverageWidth = ActureWidth / ItemSource.Count;
            //double AverageHight = ActureHight / ItemSource.Count;
            double AverageWidth = ActureWidth / 20;
            double AverageHight = ActureHight / 20;
            
            for (int i = 0; i < 10; i++)
            {
                string Location = "";
                double UpLeftX = i * AverageWidth + 150;
                double UpLeftY = 30;
                Location = Location +"M"+ UpLeftX + "," + UpLeftY + " ";
                double UpRightX = UpLeftX+ AverageWidth;
                double UpRightY = UpLeftY;
                Location = Location +"L"+UpRightX + "," + UpRightY + " ";
                double DownRightX = UpLeftX + AverageWidth;
                double DownRightY = UpRightY+ AverageHight;
                Location = Location + "L"+DownRightX + "," + DownRightY + " ";
                double DownLeftX = DownRightX- AverageWidth;
                double DownLeftY = UpRightY + AverageHight;
                Location = Location +"L"+ DownLeftX + "," + DownLeftY + " ";
                Candle candle = new Candle(Location,i);
                
                this.chartCanvas.Children.Add(candle);
                //string StartPointX = i * ActureWidth;
                //string StartPointY = i * ActureWidth;
                //string StartPointX = i * ActureWidth;
                //string StartPointY = i * ActureWidth;
                //string StartPointX = i * ActureWidth;
                //string StartPointY = i * ActureWidth;
                //string StartPointX = i * ActureWidth;
                //string StartPointY = i * ActureWidth;
            }
        }

        public ObservableCollection<string> ItemSource
        {
            get { return (ObservableCollection<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
         public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(string), typeof(LineChart), new PropertyMetadata(""));
    }
}
