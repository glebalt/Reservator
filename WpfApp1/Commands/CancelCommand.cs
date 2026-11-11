using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Stores;
using WpfApp1.Viewmodels;
using WpfApp1.Servicies;

namespace WpfApp1.Commands
{
    public class CancelCommand : CommandsBase
    {
        private readonly NavigationService service;
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        }

        public CancelCommand(NavigationService service)
        {
            this.service = service;
        }

        public override void Execute(object? parameter)
        {
            System.Diagnostics.Debug.WriteLine("SEX");
            service.UserListing();
        }
    }
}
