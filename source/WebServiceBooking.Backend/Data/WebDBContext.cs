using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.Data.Entities;


namespace WebServiceBooking.Backend.Data
{
    public class WebDBContext : ApiAuthorizationDbContext<User>
    {
        public WebDBContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false); // Mặc định Identity đã có Entities này 
            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false); 
        }

        //Entities
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<GroupItem> GroupItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MyHotelRestaurant> MyHotelRestaurants { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }





    }
}
