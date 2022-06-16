using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebServiceBooking.Data.Entities
{
    [Table("Items")]
   public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [Required]
        [MaxLength(500)]
        public string ItemName { get; set; }

        [MaxLength(20)]
        [DataType("varchar(20)")]
        public string ItemCode { get; set; }

        [DefaultValue(false)]
        public bool isOpenPrice { get; set; }// cho phep dieu chinh gia khong khi ban khong, mac dinh la khong 

        [DefaultValue(0)]
        [DataType("decimal(18,9)")]
        public decimal SalePrice { get; set; }

        //public decimal SpurchasePrice { get; set; }

        public int? CurrencyID { get; set; }

        public int? UnitID { get; set; }

        //public int? SupplierID { get; set; }

        [Required]
        public int UserID { get; set; }

        [DataType("Smalldatetime")]
        public DateTime CreateDate { get; set; }

        [DataType("Smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }

        //Foreign key for GroupItems
        public int GroupItemID { get; set; }
        public GroupItem GroupItem { get; set; }

    }
}
