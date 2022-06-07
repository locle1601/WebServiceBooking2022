using KnowledgeSpace.BackendServer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data;
using WebServiceBooking.Data.Entities;
using WebServiceBooking.ViewModels.Contents;

namespace WebServiceBooking.Backend.Controllers
{
    public class MyHotelRestaurantController : BaseController
    {
       private readonly WebDBContext _context;
       public MyHotelRestaurantController(WebDBContext context)
        {
            _context = context;
        }

        [HttpPost]
       // [ClaimRequirement(FunctionCode.CONTENT_CATEGORY, CommandCode.CREATE)]
        //[ApiValidationFilter]
        public async Task<IActionResult> PostMyHotelRestaurant([FromBody] MyHotelRestaurantCreateRequest request)
        {
            var MyHotelRestaurant = new MyHotelRestaurant()
            {
                Id = request.Id,
                HotelRestaurantCode = request.HotelRestaurantCode,
                HotelRestaurantName = request.HotelRestaurantName,
                Address = request.Address,
            };
            _context.MyHotelRestaurants.Add(MyHotelRestaurant);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetAllMyHotelRestaurants), request);
                //return CreatedAtAction(nameof(GetById), new { id = MyHotelRestaurant.Id }, request); // khi tao xong thi goi toi phuong thuc "GetbyID
            }
            else
            {
                return BadRequest();
            }
        }
        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllMyHotelRestaurants()
        {
            var hotel = await _context.MyHotelRestaurants.ToListAsync();

            var hotelVm = hotel.Select(c => MyHotelRestaurantVm(c)).ToList();

            return Ok(hotelVm);
        }

        // GET 
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var MyHotelRestaurant = await _context.MyHotelRestaurants.FindAsync(id);
            if (id == null)
                return NotFound(new ApiNotFoundResponse($" Your id: {id} is not found")); // 400

            var MyHotelRestaurantVm = new MyHotelRestaurantVm()
            {
                Id = MyHotelRestaurant.Id,
                HotelRestaurantCode = MyHotelRestaurant.HotelRestaurantCode,
                HotelRestaurantName = MyHotelRestaurant.HotelRestaurantName,
                Address = MyHotelRestaurant.Address,
            };
            return Ok(MyHotelRestaurantVm);
        }



        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyHotelRestaurant(int id, [FromBody] MyHotelRestaurantCreateRequest request)
        {
            var MyHotelRestaurant  = await _context.MyHotelRestaurants.FindAsync(id);
            if (id == null)
                return NotFound(new ApiNotFoundResponse($" Your id: {id} is not found")); // 400

            MyHotelRestaurant.Id = request.Id;
            MyHotelRestaurant.HotelRestaurantCode = request.HotelRestaurantCode;
            MyHotelRestaurant.HotelRestaurantName = request.HotelRestaurantName;
            MyHotelRestaurant.Address= request.Address;

            _context.MyHotelRestaurants.Update(MyHotelRestaurant);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetById), new { id = MyHotelRestaurant.Id }, request); // khi update xong thi goi toi phuong thuc "GetbyID
            }
            else
            {
                return BadRequest();
            }
        }

        //URL: DELETE: http://localhost:5001/api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyHotelRestaurant(int id)
        {
            var MyHotelRestaurant = await _context.MyHotelRestaurants.FindAsync(id);

            if (MyHotelRestaurant == null)
                return NotFound(new ApiNotFoundResponse($" Your id: {id} is not found")); // 400

            _context.MyHotelRestaurants.Remove(MyHotelRestaurant);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                MyHotelRestaurantVm vm = MyHotelRestaurantVm(MyHotelRestaurant);  // return: user.info by deleted
                return Ok(vm);
            };
            return Ok();
        }
        private static MyHotelRestaurantVm MyHotelRestaurantVm(MyHotelRestaurant hotelRestaurant )
        {
            return new MyHotelRestaurantVm()
            {
                Id = hotelRestaurant.Id,
                HotelRestaurantName = hotelRestaurant.HotelRestaurantName
            };
        }

    }
}
