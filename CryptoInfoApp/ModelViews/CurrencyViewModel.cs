using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using CryptoInfoApp.Views;
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

namespace CryptoInfoApp.ModelViews
{
    internal partial class CurrencyViewModel : ObservableObject
    {
        [ObservableProperty]
        private CriptoCurrency _currency;

        [ObservableProperty]
        private ObservableCollection<ExchangeCriptoCurrency> _criptoExchanges;

        private readonly ApiService apiService = new();

        public ICommand GoBackCommand { get; }
        public CurrencyViewModel(CriptoCurrency currency, ICommand goBack)
        {
            Currency = currency;
            GoBackCommand = goBack;
            DataInit(Currency.Id);
        }

        private async void DataInit(string currencyId)
        {
            CriptoExchanges = new ObservableCollection<ExchangeCriptoCurrency>(
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
