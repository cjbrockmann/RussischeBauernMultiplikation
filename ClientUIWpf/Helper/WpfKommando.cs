using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientUIWpf.Helper
{
    class WpfKommando : ICommand
    {

        public Func<bool> WhenToExecute;
        public Action WhatToExecute;

        public WpfKommando(Action what, Func<bool> when)
        {
            WhenToExecute = when;
            WhatToExecute = what;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return WhenToExecute();
        }

        public void Execute(object parameter)
        {
            WhatToExecute();
        }

        public void Refresh()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

    }
}
