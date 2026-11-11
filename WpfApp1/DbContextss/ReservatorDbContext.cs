using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WpfApp1.DTO;
using System;

namespace WpfApp1.DbContextss
{
    public class ReservatorDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; }

        public ReservatorDbContext (DbContextOptions options ) : base(options)
        {

        }
    }
}
