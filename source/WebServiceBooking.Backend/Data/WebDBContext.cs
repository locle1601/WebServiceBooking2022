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
        DbSet<User> Users { get; set; }
        DbSet<MyHotelRestaurant> MyHotelRestaurants { get; set; }

        DbSet<Branch> Branches { get; set; }

        DbSet<Venue> Venues { get; set; }

        DbSet<Table> Tables { get; set; }

        DbSet<GroupItem> GroupItems { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Unit> Units { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<Booking> Bookings { get; set; }

    }
}
