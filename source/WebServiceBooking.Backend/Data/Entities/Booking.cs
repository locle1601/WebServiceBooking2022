using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int BookingNumber { get; set; }
        public string BookingCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ToTime { get; set; }
        public int NumAdult { get; set; }
        public int NumChil { get; set; }
        public int NumNotPay { get; set; }
        public int StatusID { get; set; }

    }
}
