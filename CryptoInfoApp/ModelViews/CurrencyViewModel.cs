using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using CryptoInfoApp.Views;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using LiveChartsCore.Defaults;

namespace CryptoInfoApp.ModelViews
{
    internal partial class CurrencyViewModel : ObservableObject
    {
        [ObservableProperty]
        private Cryptocurrency _currency;

        [ObservableProperty]
        private ObservableCollection<ExchangeCryptoCurrency> _cryptoExchanges;

        private readonly ApiService apiService = new();

        public Axis[] XAxes { get; set; }

        public ISeries[] Series { get; set; }

        public ICommand GoBackCommand { get; }
        public CurrencyViewModel(Cryptocurrency currency, ICommand goBack)
        {
            Currency = currency;
            GoBackCommand = goBack;
            DataInit(Currency.Id);

            var dtp = new ObservableCollection<DateTimePoint>();
            foreach (var spark in Currency.Sparkline)
            {
                dtp.Add(new DateTimePoint(spark.Key, spark.Value));
            }
            Series = new ISeries[]
            {
                new ColumnSeries<DateTimePoint>
                {
                    Values = dtp
                }
            };

            XAxes = new[]
            {
                new DateTimeAxis(TimeSpan.FromHours(1), date => date.ToString("MM dd"))
            };
        }

        private async void DataInit(string currencyId)
        {
            CryptoExchanges = new ObservableCollection<ExchangeCryptoCurrency>(
                (await apiService.GetExchangesByCurrency(currencyId))
                .OrderBy(x => x.BaseC)
                .ThenBy(x => x.TargetC));
        }

        [RelayCommand]
        public void OpenExchangeWeb(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
