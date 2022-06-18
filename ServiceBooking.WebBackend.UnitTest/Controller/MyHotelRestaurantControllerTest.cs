using WebServiceBooking.Backend.Controllers;
using WebServiceBooking.Backend.Data;
using Moq;
using Xunit;
using ServiceBooking.WebBackend.UnitTest;
using System.Collections.Generic;
using WebServiceBooking.Data.Entities;
using System.Threading.Tasks;
using WebServiceBooking.ViewModels.Contents;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebServiceBooking.Backend.UnitTest.Controllers
{
    public class MyHotelRestaurantControllerTest
    {
        private readonly WebDBContext _context;
        public MyHotelRestaurantControllerTest()
        {
            _context = new InMemoryDbContextFactory().GetApplicationDbContext();
            _context.MyHotelRestaurants.AddRange(new List<MyHotelRestaurant>()
            {
                new MyHotelRestaurant()
                {
                    Id=1,
                    HotelRestaurantCode="HVN",
                    HotelRestaurantName="HavanaHotel",
                    Address="38 Trần Phú,Nha Trang, Khánh Hòa"
                },
               new MyHotelRestaurant()
               {
                    Id=2,
                    HotelRestaurantCode="HVN2",
                    HotelRestaurantName="HavanaHotel2",
                    Address="38 Trần Phú,Nha Trang, Khánh Hòa2"
                },
                new MyHotelRestaurant()
               {
                    Id=3,
                    HotelRestaurantCode="HVN2",
                    HotelRestaurantName="HavanaHotel2",
                    Address="38 Trần Phú,Nha Trang, Khánh Hòa2"
                },

            });
             _context.SaveChangesAsync().ConfigureAwait(true);
                                       
            }

        [Fact]
        public void Should_Create_Instance_NotNull_Success()
        {
            var controller = new MyHotelRestaurantController(_context);
            Assert.NotNull(controller);

        }
        public async Task Post_MyHotelRestaurrant_ValidInput_Success()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context );
            var result = await myHotelRestaurant.PostMyHotelRestaurant(new MyHotelRestaurantCreateRequest()
            {


                    Id=4,
                    HotelRestaurantCode="HVN4",
                    HotelRestaurantName="HavanaHotel4",
                    Address="38 Trần Phú,Nha Trang, Khánh Hòa4"

            });

            Assert.IsType<CreatedAtActionResult>(result);
        }
        public async Task Post_MyHotelRestaurrant_ValidInput_Failed()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.PostMyHotelRestaurant(new MyHotelRestaurantCreateRequest()
            {
                Id = 1,
                HotelRestaurantCode = "HVN1",
                HotelRestaurantName = "HavanaHotel1",
                Address = "38 Trần Phú,Nha Trang, Khánh Hòa1"
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public async Task GetAllMyHotelRestaurants_HasData_Return_Sucsess()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.GetAllMyHotelRestaurants();
            var okResult = result as OkObjectResult;
            var myHotelRestaurantVms = okResult.Value as IEnumerable<MyHotelRestaurantVm>;
            Assert.True(myHotelRestaurantVms.Count() > 0);
        }

        [Fact]
        public async Task Put_MyHotelRestaurant_ValidInput_Success()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.PutMyHotelRestaurant(1, new MyHotelRestaurantCreateRequest
            {
                Id = 1,
                HotelRestaurantCode = "HVN1",
                HotelRestaurantName = "HavanaHotel1",
                Address = "38 Trần Phú,Nha Trang, Khánh Hòa, Việt Nam"
            });

            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task Put_MyHotelRestaurant_ValidInput_Failed()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.PutMyHotelRestaurant(11, new MyHotelRestaurantCreateRequest
            {
                Id = 1,
                HotelRestaurantCode = "HVN1",
                HotelRestaurantName = "HavanaHotel1",
                Address = "38 Trần Phú,Nha Trang, Khánh Hòa, Việt Nam"
            });
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task DeleteMyHotelRestaurant_ValidInput_Success()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.DeleteMyHotelRestaurant(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task DeleteUser_ValidInput_Failed()
        {
            var myHotelRestaurant = new MyHotelRestaurantController(_context);
            var result = await myHotelRestaurant.DeleteMyHotelRestaurant(1);
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}