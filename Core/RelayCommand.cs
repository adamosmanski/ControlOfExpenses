﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlOfExpenses.Core
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// przechowywam metody execute ktore nic nie zwraacaja ale przyjmuja argument object
        /// </summary>
        private Action<object> _execute;
        /// <summary>
        /// zwraca wartosc logiczna
        /// </summary>
        private Func<object, bool> _canExecute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            if(execute == null) throw new ArgumentNullException(nameof(execute));
            else this._execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove 
            { 
                CommandManager.RequerySuggested -= value; 
            }
        }

        public bool CanExecute(object? parameter)
        {
            if(_canExecute==null) return true;
            else return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
