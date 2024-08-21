using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.Models;
using CryptoInfoApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoInfoApp.ModelViews
{
    internal partial class MainViewModel : ObservableObject
    {
        private readonly Stack<Page> _navigationStack = new Stack<Page>();

        [ObservableProperty]
        private Page? _currentPage;


        public bool CanGoBack() => _navigationStack.Count > 0;

        public MainViewModel()
        {
            CurrentPage = new MainPage(NavigateToCurrencyCommand, NavigateToConverterCommand);
        }

        [RelayCommand]
        private void NavigateToCurrency(Cryptocurrency selectedCurrency)
        {
            _navigationStack.Push(CurrentPage);
            CurrentPage = new CurrencyPage(selectedCurrency, GoBackCommand);
        }

        [RelayCommand]
        private void NavigateToConverter(ObservableCollection<Cryptocurrency> currencies)
        {
            _navigationStack.Push(CurrentPage);
            CurrentPage = new ConverterPage(currencies, GoBackCommand);
        }

        [RelayCommand(CanExecute = nameof(CanGoBack))]
        private void GoBack()
        {
            CurrentPage = _navigationStack.Pop();
        }
    }
}
