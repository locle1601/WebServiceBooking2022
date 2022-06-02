using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBooking.Backend.Data.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [MaxLength(20)]
        [DataType("varchar(20)")]
        public string EmployeeCode { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string MidleName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [DataType("Date")]
        public string DateOfBirth { get; set; }

        public int Telephone1 { get; set; }
        public int Telephone2 { get; set; }

        [MaxLength(20)]
        [DataType("varchar(20)")]
        public int Email1 { get; set; }

        [MaxLength(20)]
        [DataType("varchar(20)")]
        public int Email2 { get; set; }

        [Required]
        [DataType("Smalldatetime")]
        public DateTime CreateDate { get; set; }

        [DataType("Smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
