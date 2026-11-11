using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using WpfApp1.Exceptions;
using WpfApp1.Models;
using WpfApp1.Servicies;
using WpfApp1.Viewmodels;

namespace WpfApp1.Commands
{
    public class MakeReservationCommand : CommandsBase
    {

        private readonly Hotel hotel;
        MakeReservationViewModel makeResVM;
        NavigationService service;
        public MakeReservationCommand(Hotel hotel, MakeReservationViewModel vm, NavigationService service)
        {
            this.hotel = hotel;
            makeResVM = vm;
            this.service = service;
            makeResVM.PropertyChanged += OnPropertyChanged;
        }

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs a)
        {
            if(a.PropertyName == nameof(makeResVM.Username) || a.PropertyName == nameof(makeResVM.FloorNumber) || a.PropertyName == nameof(makeResVM.RoomNumber)){
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) && !string.IsNullOrEmpty(makeResVM.Username) && FloorCheck();
        }

        bool FloorCheck() => makeResVM.FloorNumber > 0 && makeResVM.RoomNumber > 0;
        public override void Execute(object? parameter)
        {
         Reservation reserv = new Reservation(new RoomID(makeResVM.FloorNumber,makeResVM.RoomNumber),makeResVM.StartDate,makeResVM.EndDate,makeResVM.Username);

            try
            {
                hotel.MakeReservation(reserv);
                MessageBox.Show("Room succesfully booked!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
           
        }
    }
}
