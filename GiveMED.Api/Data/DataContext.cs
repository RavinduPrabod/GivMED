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
        public DbSet<User> Users { get; set; }
        public DbSet<HospitalMaster> HospitalMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region KeyFields

            modelBuilder.Entity<User>().HasKey(c => new { c.UserName });

            modelBuilder.Entity<HospitalMaster>().HasKey(c => new { c.HospitalID });

            #endregion KeyFields

            #region Precisions

            #endregion Precisions

            base.OnModelCreating(modelBuilder);
        }
    }
}
