using Microsoft.AspNetCore.Identity;
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
            // them user 
            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "123456");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
          
            }
    
        }
        public static async Task SeedSampleDataAsync(WebDBContext context)
        {
            // Seed, if necessary
            if (!context.MyHotelRestaurants.Any())
            {
                context.MyHotelRestaurants.Add(new MyHotelRestaurant
                {
                    Id = 1,
                    Address = " nha trang",
                    HotelRestaurantCode = "56000",
                    HotelRestaurantName = " resrant"
                })  ;

                await context.SaveChangesAsync();
            }
        }

    }
}