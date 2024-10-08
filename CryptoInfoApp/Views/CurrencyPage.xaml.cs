﻿using CryptoInfoApp.Models;
using CryptoInfoApp.ModelViews;
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

namespace CryptoInfoApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Currency.xaml
    /// </summary>
    public partial class CurrencyPage : Page
    {
        public CurrencyPage(Cryptocurrency currency, ICommand navigationCommand)
        {
            DataContext = new CurrencyViewModel(currency, navigationCommand);
            InitializeComponent();
        }
    }
}
