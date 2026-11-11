using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.DbContextss;
using WpfApp1.DTO;
using WpfApp1.Models;

namespace WpfApp1.Servicies.ReservationCreators
{
    public class ReservationCreator : IReservationCreator
    {
        ReservatorDbContextFactory reservatorDbContextFactory;

        public ReservationCreator(ReservatorDbContextFactory factory)
        {
            reservatorDbContextFactory = factory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (ReservatorDbContext context = reservatorDbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation r)
        {
            return new ReservationDTO
            {
                FloorNumber = r.RoomID.FloorNumber,
                RoomNumber = r.RoomID.RoomNumber,
                Username = r.UserName,
                StartTime = r.start,
                EndTime = r.end

            };
        }
    }
}
