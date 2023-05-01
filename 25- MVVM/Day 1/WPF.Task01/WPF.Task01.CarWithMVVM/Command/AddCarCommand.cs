using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Task01.CarWithMVVM.Command
{
    class AddCarCommand : ICommand
    {
        Action<object> excute;
        Predicate<object> canExcute;

        public AddCarCommand(Action<object> excute, Predicate<object> canExcute)
        {
            this.excute = excute;
            this.canExcute = canExcute;
        }   

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if(canExcute != null) {

                return canExcute.Invoke(parameter);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            excute.Invoke(parameter);   
        }
    }
}
