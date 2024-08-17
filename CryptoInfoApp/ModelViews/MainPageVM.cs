using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.ApiServices;
using CryptoInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoInfoApp.ModelViews
{
    internal partial class MainPageVM : ObservableObject
    {
        private readonly ApiService apiService = new();

        [ObservableProperty]
        private ObservableCollection<CriptoCurrency>? _currencies;

        [RelayCommand()]
        public async Task RefreshChart(CancellationToken token)
        {
            Currencies = new ObservableCollection<CriptoCurrency>(await apiService.GetTopCurrenciesAsync());    
        }
    }
}
