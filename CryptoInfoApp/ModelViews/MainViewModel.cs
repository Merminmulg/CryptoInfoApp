using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoInfoApp.Models;
using CryptoInfoApp.Views;
using System;
using System.Collections.Generic;
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
            CurrentPage = new MainPage(NavigateToCurrencyCommand);
        }

        [RelayCommand]
        private void NavigateToCurrency(CriptoCurrency selectedCurrency)
        {
            _navigationStack.Push(CurrentPage);
            CurrentPage = new CurrencyPage(selectedCurrency, GoBackCommand);
        }

        [RelayCommand(CanExecute = nameof(CanGoBack))]
        private void GoBack()
        {
            CurrentPage = _navigationStack.Pop();
        }
    }
}
