using System;
using System.Windows.Input;

namespace RamekCalculator
{
    public sealed class ActionCommand : ICommand
    {
        private Action _execute;

        public ActionCommand(Action execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Action is null!");
            }

            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            _execute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}