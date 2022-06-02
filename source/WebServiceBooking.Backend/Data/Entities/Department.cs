using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBooking.Backend.Data.Entities
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  DepartmentId { get; set; }
        [MaxLength(250)]
        public string DepartmentName { get; set; }

        [MaxLength(250)]
        public string DepartmentCode { get; set; }

    }
}
