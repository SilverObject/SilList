﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Base;


namespace SO.SilList.Manager.DbContexts
{
    public partial class MainDb : BaseDbContext
    {
        public MainDb()
            : base("name=MainDb")
        {
           // this.Configuration.LazyLoadingEnabled = false;
           // this.Configuration.ProxyCreationEnabled = false;
           

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<BusinessVo> businesses { get; set; }
        public DbSet<SiteVo> sites { get; set; }
        public DbSet<JobCompanyVo> jobCompanys { get; set; }      
        public DbSet<RentalVo> rental { get; set; }
        public DbSet<BusinessCategoryTypeVo> businessCategoryType { get; set; }
        public DbSet<LeaseTermTypeVo> leaseTermType { get; set; }

    }

}
