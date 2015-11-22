using System;
using RamekCalculator.Services;

namespace RamekCalculator.ViewModels
{
    public sealed class CalculatorViewModel : ViewModelBase
    {
        private readonly CalculatorSimple _calculator;
        private Operations _operation;
        private Boolean _initialValueIsSet;
        private Boolean _isWaitingForNewValue;
        private Boolean _equationCompleted;

        private Decimal _value1;
        private Decimal _value2;
        private Decimal _result;
        private string _input = "0";
        private string _log = String.Empty;

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
                _input = FilterInput(value);
                OnPropertyChanged();
            }
        }

        public String Log
        {
            get { return _log; }
            set
            {
                _log = value;
                OnPropertyChanged();
            }
        }

        private string FilterInput(string s)
        {
            //If input is empty - return zero
            if (s.Length == 0) return "0";

            //If second digit was input and the first digit is zero - remove zero
            if (s.Length == 2 && s[0] == '0' && s[1] != ',') return s.Remove(0, 1);

            //If decimal mark was input while there is already one decimal mark in the string - remove last decimal mark
            if (s[s.Length - 1] == ',' && s.Remove(s.Length - 1, 1).Contains(",")) return s.Remove(s.Length - 1, 1);
            
            //If everything is OK - return original string
            return s;
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

            ZeroCommand = new ActionCommand(() => InputSymbol('0'));
            OneCommand = new ActionCommand(() => InputSymbol('1'));
            TwoCommand = new ActionCommand(() => InputSymbol('2'));
            ThreeCommand = new ActionCommand(() => InputSymbol('3'));
            FourCommand = new ActionCommand(() => InputSymbol('4'));
            FiveCommand = new ActionCommand(() => InputSymbol('5'));
            SixCommand = new ActionCommand(() => InputSymbol('6'));
            SevenCommand = new ActionCommand(() => InputSymbol('7'));
            EightCommand = new ActionCommand(() => InputSymbol('8'));
            NineCommand = new ActionCommand(() => InputSymbol('9'));
            MarkCommand = new ActionCommand(() => InputSymbol(','));

            RemoveLastDigitCommand = new ActionCommand(RemoveLastDigit);
            ClearCommand = new ActionCommand(Clear);
            PlusMinusCommand = new ActionCommand(ChangeSign);
        }

        #region Operations Commands

        public ActionCommand AddCommand { get; private set; }
        public ActionCommand SubtractCommand { get; private set; }
        public ActionCommand MultiplyCommand { get; private set; }
        public ActionCommand DivideCommand { get; private set; }
        public ActionCommand EquateCommand { get; private set; }

        private void Add()
        {
            if (_isWaitingForNewValue)
            {
                Log = Log.Remove(Log.Length - 1, 1);
                Log += '+';
                _operation = Operations.Addition;
                return;
            }
            Operate();
            Log += '+';
            _operation = Operations.Addition;
        }

        private void Subtract()
        {
            if (_isWaitingForNewValue)
            {
                Log = Log.Remove(Log.Length - 1, 1);
                Log += '-';
                _operation = Operations.Subtraction;
                return;
            }
            Operate();
            Log += '-';
            _operation = Operations.Subtraction;
        }

        private void Multiply()
        {
            if (_isWaitingForNewValue)
            {
                Log = Log.Remove(Log.Length - 1, 1);
                Log += '*';
                _operation = Operations.Multiplication;
                return;
            }
            Operate();
            Log += '*';
            _operation = Operations.Multiplication;
        }

        private void Divide()
        {
            if (_isWaitingForNewValue)
            {
                Log = Log.Remove(Log.Length - 1, 1);
                Log += '/';
                _operation = Operations.Division;
                return;
            }
            Operate();
            Log += '/';
            _operation = Operations.Division;
        }

        private void Equate()
        {
            if (_operation == Operations.None) return;

            Value2 = Decimal.Parse(Input);
            Result = Calculate();
            Input = Result.ToString();
            Log += Value2;
            Value1 = 0;
            Value2 = 0;
            _operation = Operations.None;
            _initialValueIsSet = false;
            _equationCompleted = true;
        }

        private void Operate()
        {
            if (_equationCompleted)
            {
                Log = String.Empty;
            }

            if (!_initialValueIsSet)
            {
                Value1 = Decimal.Parse(Input);
                Input = Value1.ToString();
                Log += Value1;
                _initialValueIsSet = true;
                _isWaitingForNewValue = true;
            }
            else
            {
                Value2 = Decimal.Parse(Input);
                Result = Calculate();
                Value1 = Result;
                Input = Result.ToString();
                Log += Value2;
                _isWaitingForNewValue = true;
            }
        }

        #endregion Operations Commands

        #region Input Commands

        public ActionCommand ZeroCommand { get; private set; }
        public ActionCommand OneCommand { get; private set; }
        public ActionCommand TwoCommand { get; private set; }
        public ActionCommand ThreeCommand { get; private set; }
        public ActionCommand FourCommand { get; private set; }
        public ActionCommand FiveCommand { get; private set; }
        public ActionCommand SixCommand { get; private set; }
        public ActionCommand SevenCommand { get; private set; }
        public ActionCommand EightCommand { get; private set; }
        public ActionCommand NineCommand { get; private set; }
        public ActionCommand MarkCommand { get; private set; }

        public void InputSymbol(char c)
        {
            if (_equationCompleted)
            {
                Log = String.Empty;
            }

            //If equation was completed - clear old value
            if (_equationCompleted || _isWaitingForNewValue)
            {
                Input = String.Empty;
                _equationCompleted = false;
                _isWaitingForNewValue = false;
            }

            Input += c;
        }

        #endregion Input Commands

        #region Other Commands

        public ActionCommand RemoveLastDigitCommand { get; private set; }
        public ActionCommand ClearCommand { get; private set; }
        public ActionCommand PlusMinusCommand { get; private set; }

        private void RemoveLastDigit()
        {
            Input = Input.Remove(Input.Length - 1, 1);
        }

        private void Clear()
        {
            Value1 = 0;
            Value2 = 0;
            Input = "0";
            Log = String.Empty;
            _operation = Operations.None;
            _initialValueIsSet = false;
        }

        private void ChangeSign()
        {
            if (Input[0] == '-')
                Input = Input.Remove(0, 1);
            else if (Decimal.Parse(Input) != 0)
                Input = '-' + Input;
        }

        #endregion Other Commands

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
                    result = Value2 == 0 ? Decimal.MaxValue : _calculator.Divide(Value1, Value2);
                    break;
                default:
                    throw new Exception("No operation was performed!");
            }
            return result;
        }
    }
}
