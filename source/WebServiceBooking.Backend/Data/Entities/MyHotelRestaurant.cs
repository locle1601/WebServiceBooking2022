﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("MyHotelRestaurant")]
    public class MyHotelRestaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string HotelRestaurantCode { get; set; }
        public string HotelRestaurantName { get; set; }
        public string Address { get; set; }

        
        //public ICollection<Branch> Branches { get; set; }
        //public ICollection<Venue> Venues { get; set; }

    }
}
