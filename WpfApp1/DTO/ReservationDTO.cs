using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp1.DTO
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }

        public int FloorNumber { get; set; }

        public int RoomNumber { get; set; }

        public string Username { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ReservationDTO()
        {
            
        }
    }
}
