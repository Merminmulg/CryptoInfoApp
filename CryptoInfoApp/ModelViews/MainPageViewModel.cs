using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using CryptoInfoApp.Utilities;
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
        [ObservableProperty]
        private string[] _languages =
{
            "ru-RU", "en-US", "ua-UA"
        };
        
        [ObservableProperty]
        private string _selectedLanguage = "en-US";

        public ICommand NavigateToCurrencyInfoCommand { get; }
        public ICommand NavigateToConverterCommand { get; }

        [ObservableProperty]
        private string _currencyFilter;

        private readonly ApiService apiService = new();

        [ObservableProperty]
        private ObservableCollection<CryptoCurrency>? _currencies;

        public MainPageViewModel(ICommand navigateToCurrencyInfoCommand, ICommand navigateToConverterCommand)
        {
            NavigateToConverterCommand = navigateToConverterCommand;
            NavigateToCurrencyInfoCommand = navigateToCurrencyInfoCommand;
            this.PropertyChanged += OnPropertyChanged;
            RefreshChart();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedLanguage))
            {
                ChangeLanguage();
            }
        }

        [RelayCommand()]
        public async void RefreshChart()
        {
            List<CryptoCurrency> temp;
            if (String.IsNullOrEmpty(CurrencyFilter))
            {
                Currencies = new ObservableCollection<CryptoCurrency>(await apiService.GetTopCurrenciesAsync());
            }
            else
            {
                temp = (await apiService.GetTopCurrenciesAsync()).Where(x => x.Id.Contains(CurrencyFilter.ToLower()) || x.Name.Contains(CurrencyFilter.ToLower())).ToList();
                Currencies = new ObservableCollection<CryptoCurrency>(temp);
            }
        }

        public void ChangeLanguage()
        {
            AppResourcesController.ChangeLanguage(SelectedLanguage);
        }

        [RelayCommand]
        public void ChangeTheme()
        {
            AppResourcesController.ChangeTheme();
        }
    }
}
