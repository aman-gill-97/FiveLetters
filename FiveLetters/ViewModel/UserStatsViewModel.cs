//using CommunityToolkit.Mvvm.ComponentModel;
//using LiveChartsCore.SkiaSharpView;
//using LiveChartsCore;
//using LiveChartsCore.SkiaSharpView.Painting;
//using SkiaSharp;
//using FiveLetters.Model;
//using System.Collections.ObjectModel;
//using System.Linq;
//using CommunityToolkit.Mvvm.Input;
//using CommunityToolkit.Maui.Alerts;
//using Microsoft.Maui.ApplicationModel.DataTransfer;

//namespace FiveLetters.ViewModel
//{
//    public partial class UserStatsViewModel : ObservableObject
//    {
//        public ObservableCollection<ISeries> Series { get; set; } = new ObservableCollection<ISeries>
//            {
//                new ColumnSeries<double>
//                {
//                    IsHoverable=false,
//                    Stroke = null,
//                    Fill = new SolidColorPaint(SKColors.SeaGreen),
//                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
//                    IgnoresBarPosition = true,
//                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
//                    DataLabelsSize=50,
//                    MaxBarWidth=60
//                }
//            };
//        public List<Axis> XAxes { get; set; } = new List<Axis>
//            {
//                    new Axis
//                    {
//                        ForceStepToMin=true,
//                        IsVisible=true,
//                        TextSize=60
//                    }
//            };
//        public List<Axis> YAxes { get; set; } = new List<Axis>
//            {
//                new Axis
//                {
//                    IsVisible=false,
//                    MinStep=1,
//                    ForceStepToMin=true,
//                }
//            };

//        [ObservableProperty]
//        UserStats userStats;

//        public UserStatsViewModel(UserStats userStats)
//        {
//            UserStats = userStats;
//            var data = userStats.data.ToArray();
//            var labels = userStats.labels.ToArray();
//            Series.First().Values = data;
//            XAxes.First().Labels = labels;
//        }

//        [ICommand]
//        public void ShareLink()
//        {
//            Share.Default.RequestAsync(new ShareTextRequest
//            {
//                Uri = "www.google.com",
//                Title = "google"
//            });
//        }
//    }
//}
