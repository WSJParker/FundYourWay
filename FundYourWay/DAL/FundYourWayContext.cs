using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FundYourWay.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FundYourWay.DAL
{
    public class FundYourWayContext : DbContext
    {
        public FundYourWayContext() : base("FundYourWayContext")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Transaction> Transtions { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
   
}