using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using CryptoInfoApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CryptoInfoApp.ModelViews
{
    internal partial class MainPageViewModel : ObservableObject
    {
        public ICommand NavigateToCurrencyInfoCommand { get; }

        private readonly ApiService apiService = new();

        [ObservableProperty]
        private ObservableCollection<CriptoCurrency>? _currencies;

        public MainPageViewModel(ICommand navigateToCurrencyInfoCommand)
        {
            NavigateToCurrencyInfoCommand = navigateToCurrencyInfoCommand;
            RefreshChart();
        }

        [RelayCommand()]
        public async void RefreshChart()
        {
            Currencies = new ObservableCollection<CriptoCurrency>(await apiService.GetTopCurrenciesAsync());
        }
    }
}
