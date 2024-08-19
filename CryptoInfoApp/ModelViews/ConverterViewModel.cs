using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoInfoApp.ModelViews
{
    internal partial class ConverterViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<CryptoCurrency> _currencies;

        [ObservableProperty]
        private CryptoCurrency _targetCurrency;
        
        [ObservableProperty]
        private CryptoCurrency _baseCurrency;

        [ObservableProperty]
        private ObservableCollection<ExchangeCryptoCurrency> _cryptoExchanges;

        [ObservableProperty]
        private double _convertedCurrencyAmount = 0;

        [ObservableProperty]
        private double _baseCurrencyAmount = 0;

        private readonly ApiService apiService = new();

        public ICommand GoBackCommand { get; }

        public ConverterViewModel(List<CryptoCurrency> currencies, ICommand GoBack) 
        {
            Currencies = new ObservableCollection<CryptoCurrency>(currencies);
            GoBackCommand = GoBack;
        }

        [RelayCommand]
        public async void ConvertCurrencies()
        {
            ConvertedCurrencyAmount = BaseCurrency.CurrentPrice * BaseCurrencyAmount / TargetCurrency.CurrentPrice;
            var temp = await apiService.GetExchangesByCurrency(BaseCurrency.Id);
            CryptoExchanges = new ObservableCollection<ExchangeCryptoCurrency>(
                temp.Where(x => x.TargetC.ToLower() == TargetCurrency.CurrencySymbol));
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
