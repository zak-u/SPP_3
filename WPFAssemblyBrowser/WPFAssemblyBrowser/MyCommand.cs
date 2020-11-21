using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFAssemblyBrowser
{
    class MyCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged;

        public MyCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object obj)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
