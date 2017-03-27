﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Freelance.Provider.EntityModels;
using System.Data.Entity;

namespace Freelance.Provider.Context
{
    public class FreelanceDbContext : IdentityDbContext<User>
    {
        public FreelanceDbContext()
            : base("FreelanceConnection", throwIfV1Schema: false)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public static FreelanceDbContext Create()
        {
            return new FreelanceDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User").Property(property=>property.UserName).HasColumnName("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            //modelBuilder.Entity<User>().HasMany(s => s.Profiles)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.UserId);
            //modelBuilder.Entity<Profile>().HasKey(k=>k.)
        }
    }
}
