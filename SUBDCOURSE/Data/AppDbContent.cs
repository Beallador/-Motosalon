using Microsoft.EntityFrameworkCore;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data
{
    public class AppDbContent : DbContext
    {
        public DbSet<Moto> Motos { get; set; }

        public AppDbContent(DbContextOptions<AppDbContent> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
