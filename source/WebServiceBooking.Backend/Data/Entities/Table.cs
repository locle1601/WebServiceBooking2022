using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("Tables")]
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableID { get; set; }

        [MaxLength(10)]
        [DataType("varchar(10)")]
        public string TableCode { get; set; }

        [MaxLength(250)]
        public string TableName { get; set; }       
        public int? MaxNumOfPax { get; set; }
        public int? SupplierID { get; set; }

    }
}
