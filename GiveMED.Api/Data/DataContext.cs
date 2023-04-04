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
        public DbSet<DonorMaster> FundraiserMaster { get; set; }
        public DbSet<EmailConfiguration> EmailConfiguration { get; set; }
        public DbSet<EmailUsers> EmailUsers { get; set; }
        public DbSet<UnsendEmailLog> UnsendEmailLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region KeyFields

            modelBuilder.Entity<User>().HasKey(c => new { c.UserName });

            modelBuilder.Entity<HospitalMaster>().HasKey(c => new { c.HospitalID });

            modelBuilder.Entity<DonorMaster>().HasKey(c => new { c.FundraiserID, c.UserName });

            modelBuilder.Entity<EmailConfiguration>().HasKey(c => new { c.ConfigurationId });

            modelBuilder.Entity<EmailUsers>().HasKey(c => new { c.UserId });

            modelBuilder.Entity<UnsendEmailLog>().HasKey(c => new { c.UserId });

            #endregion KeyFields

            #region Precisions

            #endregion Precisions

            base.OnModelCreating(modelBuilder);
        }
    }
}
