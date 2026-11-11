using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Exceptions
{
    internal class ReservationConflictException : Exception
    {
        public Reservation incReservation;
        public Reservation existReservation;

        public ReservationConflictException(Reservation incReservation, Reservation existReservation)
        {
            this.incReservation = incReservation;
            this.existReservation = existReservation;
        }

        public ReservationConflictException(string message) : base(message)
        {

        }

        public ReservationConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

       

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
