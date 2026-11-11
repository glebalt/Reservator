using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Servicies;
using WpfApp1.Stores;
using WpfApp1.Viewmodels;
namespace WpfApp1.Commands
{
    public class NavigateMakeReservationCommand : CommandsBase
    {
        private readonly NavigationService service;
        Func<ViewModelBase> createViewModel;

        public NavigateMakeReservationCommand(NavigationService service)
        {
            this.service = service; 
          
        }
        public override void Execute(object? parameter)
        {
            service.MakeReservation();
        }
    }
}
