using ERP.Mursheed.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Mursheed.ORM
{
    public class MursheedContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, string,
        IdentityUserClaim<string>,
        ApplicationUserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public MursheedContext(DbContextOptions<MursheedContext> options) : base(options)
        {

        }
        public MursheedContext()
        {

        }

        #region OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=.\\SQLExpress; Database=Mursheed; Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region DbSets
        public DbSet<ApplicationUser> UserApps { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<TransporterRating> TransporterRatings { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePlace> RoutePlaces { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RideToRoute> RideToRoutes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<DateFromTo> DateFromTos { get; set; }

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