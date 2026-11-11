using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Commands
{
    public class TestAsyncCommand : AsyncCommandBase
    {
        public override async Task ExecuteAsync(object? parameter)
        {
           await Task.Delay(1000);
            System.Diagnostics.Debug.WriteLine("ED");
        }

        public override async void Execute(object? parameter)
        {
            await ExecuteAsync(parameter);
        }
    }
}
