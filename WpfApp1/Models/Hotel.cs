using System;
using System.Collections.Generic;
using System.Text;


namespace WpfApp1.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;  

        public  string Name { get; }

        public Hotel(string name,ReservationBook book)
        {
            _reservationBook = book;
            Name = name;
        }

        public IEnumerable<Reservation> GetReservationForUser(string un)
        {

            return _reservationBook.GetReservationsByUsername(un);

        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetAllReservations();
        }

        public async Task MakeReservation(Reservation res)
        {
            await _reservationBook.AddReservation(res);
        }

    }
}
