using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Commands
{
    public abstract class AsyncCommandBase : CommandsBase
    {

        private bool IsEx
        {
            get
            {
                return isEx;
            }
            set
            {
                isEx = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && !isEx;
        }

        bool isEx;
        public override async void Execute(object? parameter)
        {

            isEx = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                isEx = false;
            }
        }

        public abstract Task ExecuteAsync(object? parameter);
        
    }
}
