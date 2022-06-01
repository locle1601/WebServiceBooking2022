using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.Data.Entities;

namespace WebServiceBooking.Backend.Data
{
    public class WebDBContext : IdentityDbContext<User>
    {
        public WebDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false); // Mặc định Identity đã có Entities này 
            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false); 
        }

        //Entities
        public DbSet<User> Users { get; set; }
        public DbSet<MyHotelRestaurant> MyHotelRestaurants { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<GroupItem> GroupItems { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Booking> Bookings { get; set; }

    }
}
