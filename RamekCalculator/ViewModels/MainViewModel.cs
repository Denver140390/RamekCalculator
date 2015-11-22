namespace RamekCalculator.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public CalculatorViewModel CalculatorViewModel { get; }

        public MainViewModel()
        {
            CalculatorViewModel = new CalculatorViewModel();
        }
    }
}
