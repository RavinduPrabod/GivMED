using GiveMED.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<HospitalMaster> HospitalMaster { get; set; }
        public DbSet<DonorMaster> DonorMaster { get; set; }
        public DbSet<EmailConfiguration> EmailConfiguration { get; set; }
        public DbSet<EmailUsers> EmailUsers { get; set; }
        public DbSet<UnsendEmailLog> UnsendEmailLog { get; set; }
        public DbSet<LastSerialNo> LastSerialNo { get; set; }
        public DbSet<LastDocSerialNo> LastDocSerialNo { get; set; }
        public DbSet<ProfileImages> ProfileImages { get; set; }
        public DbSet<ItemCatMaster> ItemCatMaster { get; set; }
        public DbSet<ItemMaster> ItemMaster { get; set; }
        public DbSet<SupplyRequestHeader> SupplyRequestHeader { get; set; }
        public DbSet<SupplyRequestDetails> SupplyRequestDetails { get; set; }
        public DbSet<DonationHeader> DonationHeader { get; set; }
        public DbSet<DonationDetails> DonationDetails { get; set; }
        public DbSet<ManageTemplate> ManageTemplate { get; set; }
        public DbSet<DonationFeedback> DonationFeedback { get; set; }
        public DbSet<VolunteerMaster> VolunteerMaster { get; set; }
        public DbSet<DonationVolunteer> DonationVolunteer { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region KeyFields

            modelBuilder.Entity<User>().HasKey(c => new { c.UserName });

            modelBuilder.Entity<HospitalMaster>().HasKey(c => new {c.UserName, c.HospitalID, c.RegistrationNo });

            modelBuilder.Entity<DonorMaster>().HasKey(c => new { c.DonorID, c.UserName });

            modelBuilder.Entity<EmailConfiguration>().HasKey(c => new { c.ConfigurationId });

            modelBuilder.Entity<EmailUsers>().HasKey(c => new { c.UserId });

            modelBuilder.Entity<UnsendEmailLog>().HasKey(c => new { c.UserId });

            modelBuilder.Entity<LastSerialNo>().HasKey(c => new { c.DonorType});

            modelBuilder.Entity<LastDocSerialNo>().HasKey(c => new { c.DocCode });

            modelBuilder.Entity<ProfileImages>().HasKey(c => new { c.UserName });

            modelBuilder.Entity<ItemCatMaster>().HasKey(c => new { c.ItemCatID });

            modelBuilder.Entity<ItemMaster>().HasKey(c => new { c.ItemID });

            modelBuilder.Entity<SupplyRequestHeader>().HasKey(c => new { c.HospitalID, c.SupplyID });

            modelBuilder.Entity<SupplyRequestDetails>().HasKey(c => new { c.SupplyID, c.SupplyItemID });

            modelBuilder.Entity<DonationHeader>().HasKey(c => new { c.DonationID, c.DonorID, c.UserName, c.SupplyID });

            modelBuilder.Entity<DonationDetails>().HasKey(c => new { c.DonationID, c.SupplyID, c.ItemCategory, c.ItemID });

            modelBuilder.Entity<ManageTemplate>().HasKey(c => new { c.HospitalID, c.TemplateID });

            modelBuilder.Entity<DonationFeedback>().HasKey(c => new { c.DonationID, c.SupplyCode });

            modelBuilder.Entity<VolunteerMaster>().HasKey(c => new { c.VolCode });

            modelBuilder.Entity<DonationVolunteer>().HasKey(c => new { c.DonationCode, c.SupplyCode, c.VolunteerCode, c.HospitalID, c.DonorID });

            modelBuilder.Entity<Complaint>().HasKey(c => new { c.ComplaintCode });

            #endregion KeyFields

            #region Precisions

            #endregion Precisions

            base.OnModelCreating(modelBuilder);
        }
    }
}
