using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.Data.Entities;

namespace WebServiceBooking.Backend.Data
{

    // Thêm dữ liệu ảo
    public static class DbContextSeed
    {
        // thêm user và quyền của nó
        public static async Task SeedDefaultUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");
            var userRole = new IdentityRole("Member");

            // tạo quyền  admin
            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            // tạo quyền  ng dùng
            if (roleManager.Roles.All(r => r.Name != userRole.Name))
            {
                await roleManager.CreateAsync(userRole);
            }

            var administrator = new User { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (!userManager.Users.Any())
            {
                var result = await userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = administrator.UserName,
                    FirstName = "admin",
                    LastName = "1",
                    Email = administrator.Email,
                    LockoutEnabled = false
                }, "Admin@123");
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync("administrator@localhost");
                    await userManager.AddToRoleAsync(user, administratorRole.Name);
                }


            }
        }
        public static async Task SeedSampleDataAsync(WebDBContext context)
        {
            // Seed, if necessary
            //if (!context.MyHotelRestaurants.Any())
            //{
            //    context.MyHotelRestaurants.Add(new MyHotelRestaurant
            //    {
            //        Id = 1,
            //        Address = " nha trang",
            //        HotelRestaurantCode = "56000",
            //        HotelRestaurantName = " resrant"
            //    })  ;

            //    await context.SaveChangesAsync();
            //}
        }

    }
}