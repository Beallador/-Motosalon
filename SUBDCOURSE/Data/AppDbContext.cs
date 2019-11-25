using Microsoft.EntityFrameworkCore;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
