﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MobilePride.Data.Configurations;
using MobilePride.Entity;

namespace MobilePride.Data
{
    public class MobilePrideContext : IdentityDbContext<IdentityUser>
    {
        public MobilePrideContext()
            : base("MobilePride")
        {
            Database.SetInitializer<MobilePrideContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<County> CountySet { get; set; }


        #endregion

        public virtual void Commit()
        {
            SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CountyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
