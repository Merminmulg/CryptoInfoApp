using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfoApp.Utilities
{
    internal static class AppResourcesController
    {
        private static ResourceDictionary? _langDictionary = null;
        private static ResourceDictionary? _themeDictionary = null;
        public static void ChangeLanguage(string languageUri)
        {
            if (_langDictionary != null)
                App.Current.Resources.MergedDictionaries.Remove(_langDictionary);
            Uri uri = new Uri("/Resources/lang."+languageUri+".xaml", UriKind.Relative);
            ResourceDictionary Lang = new ResourceDictionary() { Source = uri };
            _langDictionary = Lang;
            App.Current.Resources.MergedDictionaries.Add(Lang);

        }
        public static void ChangeTheme(string themeUri)
        {
            if (_themeDictionary != null)
                App.Current.Resources.MergedDictionaries.Remove(_themeDictionary);
            Uri uri = new Uri("/Resources/theme." + themeUri + ".xaml", UriKind.Relative);
            ResourceDictionary Theme = new ResourceDictionary() { Source = uri };
            _themeDictionary = Theme;
            App.Current.Resources.MergedDictionaries.Add(Theme);

        }
    }
}
