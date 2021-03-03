using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Candle.xaml 的交互逻辑
    /// </summary>
    public partial class Candle : UserControl
    {
        public Candle()
        {
            InitializeComponent();
           // ContructCandle();
        }
        public Candle(string Location, int Index) :this()
        {
            ContructCandle(Location,  Index);
        }
        public Candle(string Height, string Width, string HNo, string WNo, string Index, string Open, string Close, string Highest, string Lowest) : this()
        {
            //ContructCandle( Height,  Width,  HNo,  WNo,  Index,  Open,  Close,  Highest,  Lowest);


        }
        private void ContructCandle(string Location,int Index)/*(string Height,string Width,string HNo,string WNo,string Index,string Open,string Close,string Highest,string Lowest)  */          
        {

            string PathData = Location;// "M0.5,31.079 L56.632,31.079 L56.632,130.079 L0.5,130.079 z M29.044005,0.50000004 L29.566993,31.078997 M28.567005,130.579 L28.567005,158.7";
            Path path = new Path();
            string sData = PathData;
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            path.Data = (Geometry)converter.ConvertFrom(sData);
            CandleLocation.Data = path.Data;
            Canvas.SetLeft(this,100* Index);
        }
    }
}
