using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("Branches")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchID { get; set; }

        [MaxLength(250)]
        public string BranchName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        public int MyHotelRestaurantID { get; set; }
        //public MyHotelRestaurant MyHotelRestaurant { get; set; }
        //public ICollection<Venue> Venues { get; set; }
    }
}
