using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Exceptions;
using WpfApp1.Servicies.ReservationConflictValidators;
using WpfApp1.Servicies.ReservationCreators;
using WpfApp1.Servicies.ReservationsProviders;
namespace WpfApp1.Models
{
    public  class ReservationBook
    {
        private readonly List<Reservation> _reservations;
        public HashSet<string> users;

        private readonly IReservationProvider provider;
        private readonly IReservationCreator creator;
        private readonly IReservationConflictValidator conflictValidator;
        public ReservationBook(IReservationCreator c, IReservationProvider p ,IReservationConflictValidator v)
        {
            provider = p;
            creator = c;
            conflictValidator = v;
        }

        public IEnumerable<Reservation> GetReservationsByUsername(string userName)
        {
            if (!users.Contains(userName))
            {
                return Enumerable.Empty<Reservation>();
            }

            return _reservations.Where(r => r.UserName == userName);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await provider.GetAllReservationsAsync();
        }

        public async Task AddReservation(Reservation reservation)
        {
            Reservation res = await conflictValidator.GetConflictingReservation(reservation);

            if (res != null) {
                throw new ReservationConflictException(reservation,res);
            }
            
           await creator.CreateReservation(reservation);
        }
    }
}
