using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
   public class MyHotelRestaurant
    {
        public int HotelRestaurantID { get; set; }
        public string HotelRestaurantCode { get; set; }
        public string HotelRestaurantName { get; set; }
        public string Address { get; set; }
        //public ICollection<Branch> Branches { get; set; }
        //public ICollection<Venue> Venues { get; set; }

    }
}
