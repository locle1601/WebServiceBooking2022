using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("Currencies")]
    public  class Currency
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyID { get; set; }

        [Required]
        public String CurrencyName { get; set; }

        [DataType("varchar(5)")]
        public String CurrencyCode { get; set; }

        [DataType("varchar(50)")]
        public string UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
