using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BloodDonationManagementSystem.Models
{
    public class DataBase : DbContext
    {
        public DbSet<Donor> Donors { get; set; }

        public DataBase() : base("DonorDatabase")
        {

        }

    }
}