using CryptoInfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptoInfoApp.ModelViews;
using System.Collections.ObjectModel;

namespace CryptoInfoApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ConverterPage.xaml
    /// </summary>
    public partial class ConverterPage : Page
    {
        public ConverterPage(ObservableCollection<Cryptocurrency> currencies, ICommand command)
        {
            DataContext = new ConverterViewModel(currencies.ToList(), command);
            InitializeComponent();
        }
    }
}
