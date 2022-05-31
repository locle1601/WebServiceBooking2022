using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public int MyHotelRestaurantID { get; set; }
        //public MyHotelRestaurant MyHotelRestaurant { get; set; }
        //public ICollection<Venue> Venues { get; set; }
    }
}
