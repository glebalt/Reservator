using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.DbContextss;
using WpfApp1.DTO;
using WpfApp1.Models;

namespace WpfApp1.Servicies.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        ReservatorDbContextFactory factory;
        public DatabaseReservationConflictValidator(ReservatorDbContextFactory factory)
        {
            this.factory = factory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation res)
        {
            using (ReservatorDbContext context = factory.CreateDbContext())
            {
                return await context.Reservations.Select(r => ToReservation(r)).FirstOrDefaultAsync(r => r.Conflicts(res));
            }
        }

        Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.StartTime, dto.EndTime, dto.Username);
        }
    }
}
