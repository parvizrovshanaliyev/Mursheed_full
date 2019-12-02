using System;
using System.Collections.Generic;
using System.Text;
using ERP.Atlas.Entities;
using ERP.Atlas.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Atlas.ORM
{
    public class AtlasContext : IdentityDbContext<ApplicationUser,
                                ApplicationRole, string,
                                IdentityUserClaim<string>,
                                ApplicationUserRole,
                                IdentityUserLogin<string>,
                                IdentityRoleClaim<string>,
                                IdentityUserToken<string>>
    {
        public AtlasContext(DbContextOptions options) : base(options)
        {

        }
        public AtlasContext()
        {

        }

        #region OnConfiguring



        #endregion

        #region DbSets
        public DbSet<ApplicationUser> UserApps { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Person> Personnel { get; set; }



        #endregion

        #region OnModelCreate Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Seed
            modelBuilder.Entity<Person>().HasData(

                new Person()
                {
                    Id = 1,
                    Firstname = "Samir",
                    Lastname = "Karimov",
                    FatherName = "Karimov",
                    Email = "samir@code.edu.az"
                }
            );
            #endregion //Seed

            #region Fulent API 

            #region Identity
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.ApplicationUserRoles)
                    .WithOne(e => e.ApplicationUser)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.ApplicationUserRoles)
                    .WithOne(e => e.ApplicationRole)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });


            #endregion


            #endregion  // fulent api
           
        }
        #endregion // OnModelCreate Seeding 



    }
}