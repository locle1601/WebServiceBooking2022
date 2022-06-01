using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Data.Entities;

namespace WebServiceBooking.Backend.Data.Entities
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        [MaxLength(10)]
        [DataType("varchar(10)")]
        public string StatusCode { get; set; }

        [MaxLength(100)]
        public string StatusName { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
