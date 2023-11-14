using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _4kurs.Classes;

namespace _4kurs
{
    public class ApplicationContext : DbContext
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<HotelRoom> hotelroom => Set<HotelRoom>();
        public DbSet<Booking> booking => Set<Booking>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=1234;Database=hotel");
        }
    }
}