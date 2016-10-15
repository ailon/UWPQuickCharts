using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ChartApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private ObservableCollection<TestDataItem> _data = new ObservableCollection<TestDataItem>()
        {
            new TestDataItem() { cat1 = "cat1", val1=5, val2=15, val3=12},
            new TestDataItem() { cat1 = "cat2", val1=15.2, val2=1.5, val3=2.1},
            new TestDataItem() { cat1 = "cat3", val1=25, val2=5, val3=2},
            new TestDataItem() { cat1 = "cat4", val1=8.1, val2=1, val3=22},
        };

        ObservableCollection<PieDataItem> _piedata = new ObservableCollection<PieDataItem>()
            {
                new PieDataItem() { Title = "s1", Value = 10 },
                new PieDataItem() { Title = "s2", Value = 30 },
                new PieDataItem() { Title = "s3", Value = 20 },
                new PieDataItem() { Title = "s4", Value = 80 }
            };


        public ObservableCollection<TestDataItem> Data { get { return _data; } }
        public ObservableCollection<PieDataItem> PieData { get { return _piedata; } }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }
    }

    public class TestDataItem
    {
        public string cat1 { get; set; }
        public double val1 { get; set; }
        public double val2 { get; set; }
        public double val3 { get; set; }
    }

    public class PieDataItem : INotifyPropertyChanged
    {
        public string Title { get; set; }


        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}
