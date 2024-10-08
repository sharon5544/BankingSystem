using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace BankingProject
{
    public class AccountTypeViewModel : INotifyPropertyChanged
    {
        public PlotModel PieChartModel { get; set; }
        public ObservableCollection<string> AccountTypes { get; set; }
        public AccountTypeViewModel(ObservableCollection<AccountModel> accounts)
        {
            PieChartModel = new PlotModel { Title = "Accounts by Type" };

            AccountTypes = new ObservableCollection<string>();
            CreatePieChart(accounts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreatePieChart(ObservableCollection<AccountModel> accounts)
        {
            var series = new PieSeries
            {
                StrokeThickness = 2,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            var accountGroups = accounts.GroupBy(a => a.AccType)
                .Select(g => new { Type = g.Key, TotalBalance = g.Sum(a => a.Balance) })
                .ToList();

            var random = new Random();

            foreach (var group in accountGroups)
            {
                var color = OxyColor.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                series.Slices.Add(new PieSlice(group.Type, (double)group.TotalBalance) { Fill = color });
                AccountTypes.Add(group.Type);
            }

            PieChartModel.Series.Add(series);
        }
    }
}