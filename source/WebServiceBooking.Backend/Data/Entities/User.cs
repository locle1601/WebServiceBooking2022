using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBooking.Backend.Data.Entities
{
    public class User: IdentityUser // ke thua tu IdentityUser
    {

        [MaxLength(50)]

        public string FirstName { get; set; }

        [MaxLength(50)]

        public string LastName { get; set; }


        public DateTime Dob { get; set; }

        public int EmployeeId { get; set; }
         


        [DataType("Smalldatetime")]
        public DateTime CreateDate { get; set; }

        [DataType("Smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
