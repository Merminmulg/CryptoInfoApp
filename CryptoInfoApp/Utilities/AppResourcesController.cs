using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoInfoApp.Utilities
{
    internal static class AppResourcesController
    {
        private static ResourceDictionary _langDictionary = new ResourceDictionary() { Source = new Uri("/Resources/lang.en-US.xaml", UriKind.Relative) };
        private static ResourceDictionary _themeDictionary = new ResourceDictionary() { Source = new Uri("/Resources/Themes/theme.dark.xaml", UriKind.Relative) };
        private static bool _isDark = true;
        public static void ChangeLanguage(string languageUri)
        {
            App.Current.Resources.MergedDictionaries.Remove(_langDictionary);
            Uri uri = new Uri("/Resources/lang."+languageUri+".xaml", UriKind.Relative);
            ResourceDictionary Lang = new ResourceDictionary() { Source = uri };
            _langDictionary = Lang;
            App.Current.Resources.MergedDictionaries.Add(Lang);

        }
        public static void ChangeTheme()
        {

            App.Current.Resources.MergedDictionaries.Remove(_themeDictionary);
            Uri uri;
            if (!_isDark)
            {
                uri = new Uri("/Resources/Themes/theme.dark.xaml", UriKind.Relative);
            }
            else
            {
                uri = new Uri("/Resources/Themes/theme.light.xaml", UriKind.Relative);
            }
            _isDark = !_isDark;
            ResourceDictionary Theme = new ResourceDictionary() { Source = uri };
            _themeDictionary = Theme;
            App.Current.Resources.MergedDictionaries.Add(Theme);

        }
    }
}
