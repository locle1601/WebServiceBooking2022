using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    public class Table
    {
        public int TableID { get; set; }
        public string TableCode { get; set; }
        public string TableName { get; set; }       
        public int MaxPax { get; set; }

    }
}
