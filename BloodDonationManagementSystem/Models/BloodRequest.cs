using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http;

namespace BloodDonationManagementSystem.Models
{
    public class BloodRequest
    {
        [Key]
        public int RequestId { get; set; }
        [ForeignKey("Donor")]
        public int DonorID { get; set; }
        [HttpBindRequired]
        public string HospitalName { get; set; }

        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }           
        
        public DateTime RequestDate { get; set; }

        public Donor Donor { get; set; }
    }
}