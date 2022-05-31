using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
   public class Item
    {
        public int ItemID { get; set; }
        public int ItemName { get; set; }
        public int ItemCode { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }


    }
}
