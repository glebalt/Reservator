using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Viewmodels
{
   public class ReservationViewModel : ViewModelBase
    {

       private readonly  Reservation _reservation;
        public string RoomID  => _reservation.RoomID?.ToString();
        public string Username => _reservation.UserName.ToString();
        public string Start => _reservation.start.ToString("d");
        public string End => _reservation.end.ToString("d");

        public ReservationViewModel(Reservation res)
        {
            _reservation = res;
        }

    }
}
