using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.ViewModels.Contents
{
   public class BranchCreateRequest 
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public int MyHotelRestaurantID { get; set; }
    }
}
