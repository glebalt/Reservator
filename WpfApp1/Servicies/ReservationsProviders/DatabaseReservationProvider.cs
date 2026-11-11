using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.DbContextss;
using WpfApp1.Models;
using WpfApp1.DTO;

namespace WpfApp1.Servicies.ReservationsProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReservatorDbContextFactory reservatorDbContextFactory;
        public DatabaseReservationProvider(ReservatorDbContextFactory factory)
        {
            reservatorDbContextFactory = factory;
        }
        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
           using (ReservatorDbContext dbContext =  reservatorDbContextFactory.CreateDbContext())
            {
              IEnumerable<ReservationDTO> reservations =   await dbContext.Reservations.ToListAsync();

               return reservations.Select(r => ToReservation(r));
            }
        }

        Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber,dto.RoomNumber),dto.StartTime,dto.EndTime,dto.Username);
        }
    }
}
