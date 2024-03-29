﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using WebServiceBooking.Backend.Data.Entities;

namespace WebServiceBooking.Data.Entities
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public int MyHotelRestaurantId { get; set; }
       
        public int? BranchId { get; set; }

        [Required]
        public int BookingNumber { get; set; }

        [MaxLength(25)]
        [Column(TypeName = "varchar(20)")]
        public string BookingCode { get; set; }

        [Required]
        [DataType("Datetime")]
        public DateTime FromDate { get; set; }

        [Required]
        [DataType("Smalldatetime")]
        public DateTime FromTime { get; set; }

        [Required]
        [DataType("Datetime")]
        public DateTime ToDate { get; set; }

        [Required]
        [DataType("Smalldatetime")]
        public DateTime ToTime { get; set; }

        [Required]
        public int NumAdult { get; set; }

        [Required]
        public int NumChil { get; set; }

        [DefaultValue(0)]
        public int NumNotPay { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [DefaultValue(1)] // trang thai khách xác định đến
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Required]
        public int UserID { get; set; }

        [DataType("Smalldatetime")]
        public DateTime CreateDate { get; set; }

        [DataType("Smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }

    }
}
