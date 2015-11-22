using System;

namespace RamekCalculator
{
    public sealed class CalculatorViewModel : ViewModelBase
    {
        private readonly CalculatorSimple _calculator;
        private Operations _operation;
        private Boolean _initialValueIsSet;

        private Decimal _value1;
        private Decimal _value2;
        private Decimal _result;
        private string _input;

        #region Properties

        public Decimal Value1
        {
            get { return _value1; }
            private set
            {
                _value1 = value;
                OnPropertyChanged();
            }
        }

        public Decimal Value2
        {
            get { return _value2; }
            private set
            {
                _value2 = value;
                OnPropertyChanged();
            }
        }

        public Decimal Result
        {
            get { return _result; }
            private set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public String Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        public CalculatorViewModel()
        {
            _calculator = new CalculatorSimple();
            _operation = Operations.None;

            AddCommand = new ActionCommand(Add);
            SubtractCommand = new ActionCommand(Subtract);
            MultiplyCommand = new ActionCommand(Multiply);
            DivideCommand = new ActionCommand(Divide);
            EquateCommand = new ActionCommand(Equate);
        }

        #region Commands

        public ActionCommand AddCommand { get; private set; }
        public ActionCommand SubtractCommand { get; private set; }
        public ActionCommand MultiplyCommand { get; private set; }
        public ActionCommand DivideCommand { get; private set; }
        public ActionCommand EquateCommand { get; private set; }

        private void Add()
        {
            Equate();
            _operation = Operations.Addition;
        }

        private void Subtract()
        {
            Equate();
            _operation = Operations.Subtraction;
        }

        private void Multiply()
        {
            Equate();
            _operation = Operations.Multiplication;
        }

        private void Divide()
        {
            Equate();
            _operation = Operations.Division;
        }

        private void Equate()
        {
            if (!_initialValueIsSet)
            {
                Value1 = Decimal.Parse(Input);
                _initialValueIsSet = true;
                Input = String.Empty;
            }
            else
            {
                Value2 = Decimal.Parse(Input);
                Result = Calculate();
                Value1 = Result;
                Input = String.Empty;
            }
        }

        #endregion Commands

        private Decimal Calculate()
        {
            Decimal result;
            switch (_operation)
            {
                case Operations.None:
                    throw new Exception("Arithmetic operation was not set.");
                    break;
                case Operations.Addition:
                    result = _calculator.Add(Value1, Value2);
                    break;
                case Operations.Subtraction:
                    result = _calculator.Subtract(Value1, Value2);
                    break;
                case Operations.Multiplication:
                    result = _calculator.Multiply(Value1, Value2);
                    break;
                case Operations.Division:
                    result = _calculator.Divide(Value1, Value2);
                    break;
                default:
                    throw new Exception("No operation was performed!");
            }
            return result;
        }
    }
}
