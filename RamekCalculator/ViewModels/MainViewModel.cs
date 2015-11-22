using System;
using System.IO;
using System.Windows;

namespace RamekCalculator.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private Random _random;
        private String[] _themeNames;

        public CalculatorViewModel CalculatorViewModel { get; }

        public MainViewModel()
        {
            _random = new Random();
            _themeNames = Directory.GetFiles(@"Themes", "*.xaml");
            CalculatorViewModel = new CalculatorViewModel();
            ChangeThemeCommand = new ActionCommand(ChangeTheme);
        }

        public ActionCommand ChangeThemeCommand { get; private set; }

        private void ChangeTheme()
        {
            var app = (App)Application.Current;
            var rand = new Random();
            var uri = new Uri(_themeNames[rand.Next(_themeNames.Length)], UriKind.Relative);
            app.ChangeTheme(uri);
        }
    }
}
