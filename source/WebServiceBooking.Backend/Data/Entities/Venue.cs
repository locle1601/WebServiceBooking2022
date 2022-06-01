using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("Venues")]
    public class Venue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenueID { get; set; }

        [Required]
        public int MyHotelRestaurantID { get; set; }
        public int? BranchID { get; set; }

        [Required]
        [MaxLength(500)]
        public string VenueName { get; set; }

        [MaxLength(500)]
        public string DescriptionLocation { get; set; }

        public int? MaxNumOfTable { get; set; }

        [DataType("varchar(50)")]
        public string UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        //public MyHotelRestaurant MyHotelRestaurant { get; set; }
        //public Branch Branch { get; set; }


    }
}
