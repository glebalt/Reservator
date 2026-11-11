using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Servicies;
using WpfApp1.Stores;

namespace WpfApp1.Viewmodels
{
    class ReservationListingViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        public ICommand MakeReservationCommand { get; }

        private readonly ObservableCollection<ReservationViewModel> _reservationsObservable;
        public IEnumerable<ReservationViewModel> Reservations => _reservationsObservable;
        public ReservationListingViewModel(Hotel hotel, NavigationService service)
        {
            _hotel = hotel;

            MakeReservationCommand = new NavigateMakeReservationCommand(service);

            _reservationsObservable = new();
           // _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(0, 4), new DateTime(2026, 08, 03), new DateTime(2026, 08, 06), "Bleb")));
           // _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), new DateTime(2026, 08, 05), new DateTime(2026, 08, 011), "Ebda")));
           // _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 5), new DateTime(2026, 08, 01), new DateTime(2026, 08, 20), "Meyer")));

            UpdateReservations();
        }

        async void UpdateReservations()
        {
            _reservationsObservable.Clear();

            foreach (var res in await _hotel.GetAllReservations()) {
                _reservationsObservable.Add(new ReservationViewModel(res));
            }

        }
    }
}
