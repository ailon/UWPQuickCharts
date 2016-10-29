using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoApp
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

        private ObservableCollection<OsDataItem> _osData = new ObservableCollection<OsDataItem>()
        {
            new OsDataItem() { Name="Windows", Value=569 },
            new OsDataItem() { Name="macOS", Value=98 },
            new OsDataItem() { Name="iOS", Value=485 },
            new OsDataItem() { Name="Android", Value=784 },
            new OsDataItem() { Name="Other", Value=56 }
        };

        private ObservableCollection<VisitDataItem> _visitData = new ObservableCollection<VisitDataItem>();

        private ObservableCollection<RealTimeDataItem> _realTimeData = new ObservableCollection<RealTimeDataItem>();

        public ObservableCollection<OsDataItem> OsData { get { return _osData; } }

        public ObservableCollection<VisitDataItem> VisitData { get { return _visitData; } }

        public ObservableCollection<RealTimeDataItem> RealTimeData { get { return _realTimeData; } }

        DispatcherTimer _timer = new DispatcherTimer();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillVisitsData();
            FillInitialRealTimeData();

            this.DataContext = this;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += UpdateRealTimeData;
            _timer.Start();
        }


        private void FillVisitsData()
        {
            var startDate = DateTime.Today.AddMonths(-1);
            var visits = 200;
            var newVisits = 50;
            var pageviews = 390;

            var rnd = new Random();

            for (var date = startDate; date<DateTime.Today; date = date.AddDays(1))
            {
                VisitData.Add(new VisitDataItem()
                {
                    Date = date.ToString("MMM-dd"),
                    Visits = visits,
                    NewVisits = newVisits,
                    PageViews = pageviews
                });

                visits += (int)(50 * (rnd.NextDouble() - 0.3));
                newVisits += (int)(30 * (rnd.NextDouble() - 0.3));
                pageviews += (int)(80 * (rnd.NextDouble() - 0.3));
            }
        }

        private void FillInitialRealTimeData()
        {
            var startDate = DateTime.Now.AddSeconds(-15);
            var visits = 10;

            var rnd = new Random();

            for (var date = startDate; date < DateTime.Now; date = date.AddSeconds(1))
            {
                RealTimeData.Add(new RealTimeDataItem()
                {
                    Seconds = date.Second,
                    Visits = visits
                });

                visits += (int)(5 * (rnd.NextDouble() - 0.5));
                visits = visits < 0 ? 0 : visits;
            }
        }
        private void UpdateRealTimeData(object sender, object e)
        {
            RealTimeData.RemoveAt(0);

            var rnd = new Random();
            var visits = RealTimeData[RealTimeData.Count - 1].Visits;
            visits += (int)(5 * (rnd.NextDouble() - 0.5));
            visits = visits < 0 ? 0 : visits;

            RealTimeData.Add(new RealTimeDataItem()
            {
                Seconds = DateTime.Now.Second,
                Visits = visits
            });
        }
    }

    public class OsDataItem
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class VisitDataItem
    {
        public string Date { get; set; }
        public int Visits { get; set; }
        public int NewVisits { get; set; }
        public int PageViews { get; set; }
    }

    public class RealTimeDataItem
    {
        public int Seconds { get; set; }
        public int Visits { get; set; }
    }
}
