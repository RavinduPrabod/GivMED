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
        public DbSet<FundraiserMaster> FundraiserMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region KeyFields

            modelBuilder.Entity<User>().HasKey(c => new { c.UserName });

            modelBuilder.Entity<HospitalMaster>().HasKey(c => new { c.HospitalID });

            modelBuilder.Entity<FundraiserMaster>().HasKey(c => new { c.FundraiserID });

            #endregion KeyFields

            #region Precisions

            #endregion Precisions

            base.OnModelCreating(modelBuilder);
        }
    }
}
