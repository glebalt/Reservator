using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DbContextss
{
    public class ReservatorDbContextFactory
    {
        private readonly string connection_string;
        public ReservatorDbContextFactory(string cs)
        {
            connection_string = cs;
        }

        public ReservatorDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connection_string).Options;

            return new ReservatorDbContext(options);
        }
    }
}
