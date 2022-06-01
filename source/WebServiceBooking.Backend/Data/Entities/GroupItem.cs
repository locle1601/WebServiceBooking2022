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

        [DataType("varchar(50)")]
        public string UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public ICollection<Item> Items { get; set; }
    }        

}
