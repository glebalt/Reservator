using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Servicies.ReservationsProviders
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    }
}
