using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BloodDonationManagementSystem.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }
        [Column("Name", Order = 1)]
        [HttpBindRequired]
        [StringLength(50, MinimumLength = 3)]
        public string DonorName { get; set; }
        public int Age { get; set; }
        public BloodType BloodType { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastDonationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public string ImagePath { get; set; }

        public List<BloodRequest> BloodRequests { get; set; } = new List<BloodRequest>();
    }

    public enum BloodType
    {
        A_Positive,
        A_Negative,
        B_Positive,
        B_Negative,
        O_Positive,
        O_Negative,
        AB_Positive,
        AB_Negative


    }
}