using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string DescriptionLocation { get; set; }
        public int MyHotelRestaurantID { get; set; }
        public int BranchID { get; set; }
        //public MyHotelRestaurant MyHotelRestaurant { get; set; }
        //public Branch Branch { get; set; }


    }
}
