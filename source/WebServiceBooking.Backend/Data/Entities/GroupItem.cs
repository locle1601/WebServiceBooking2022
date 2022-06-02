using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("GroupItems")]
   public class GroupItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupItemID { get; set; }

        [MaxLength(8)]
        [DataType("varchar(8)")]
        public string GroupItemCode { get; set; }

        [MaxLength(500)]
        [Required]
        public string GroupItemName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? UserID { get; set; }

        [DataType("Smalldatetime")]
        public DateTime CreateDate { get; set; }

        [DataType("Smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }

        public ICollection<Item> Items { get; set; }
    }        

}
