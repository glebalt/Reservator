using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.DTO;

namespace WpfApp1.DbContextss
{
    public class ReservatorDesignTimeDBContextFactory : IDesignTimeDbContextFactory<ReservatorDbContext>
    {

        

       
        public ReservatorDbContext CreateDbContext(string[] args)
        {
           DbContextOptions options =  new DbContextOptionsBuilder().UseSqlite("Data Source=reservator.db").Options;

            return new ReservatorDbContext(options);
        }
    }
}
