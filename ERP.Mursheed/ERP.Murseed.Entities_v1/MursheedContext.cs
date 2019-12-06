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

            modelBuilder.Entity<Brand>().HasData(

                new Brand()
                {
                    Id = 1,
                    Name= "Volkswagen"
                }
            );

            modelBuilder.Entity<Model>().HasData(

                new Model()
                {
                    Id = 1,
                    Name = "Touareg",
                    BrandId=1
                }
            );
            modelBuilder.Entity<Car>().HasData(

                new Car()
                {
                    Id = 1,
                    ModelId = 1
                }
            );
            modelBuilder.Entity<Transporter>().HasData(

                new Transporter()
                {
                    Id = 1,
                    Firstname = "Parviz",
                    Lastname = "Ali",
                    FatherName = "Rovshan",
                    CarId=1,
                    GovernmentalId=123456789
                }
            );
            modelBuilder.Entity<Tourist>().HasData(

                new Tourist()
                {
                    Id = 1,
                    Firstname = "Heci",
                    Lastname = "Hecili",
                    FatherName = "Heci Oglu",
                }
            );

            modelBuilder.Entity<Country>().HasData(

                new Country() { Id = 1,Name="Azerbaijan"}
            );
            modelBuilder.Entity<City>().HasData(

                new City() { Id = 1,CountryId=1, Name = "Baki" },
                new City() { Id = 2,CountryId=1, Name = "Sumqayit" },
                new City() { Id = 3,CountryId=1, Name = "Gence" },
                new City() { Id = 4,CountryId=1, Name = "Quba" },
                new City() { Id = 5,CountryId=1, Name = "Qusar" },
                new City() { Id = 6,CountryId=1, Name = "Seki" },
                new City() { Id = 7,CountryId=1, Name = "Xacmaz" },
                new City() { Id = 8,CountryId=1, Name = "Mingecevir" },
                new City() { Id = 9,CountryId=1, Name = "Xacmaz" }
            );

            modelBuilder.Entity<RoutePlace>().HasData(

                new RoutePlace() { Id = 1, Name = "Baki" },
                new RoutePlace() { Id = 2, Name = "Sumqayit" },
                new RoutePlace() { Id = 3, Name = "Gence" },
                new RoutePlace() { Id = 4, Name = "Quba" },
                new RoutePlace() { Id = 5, Name = "Qusar" },
                new RoutePlace() { Id = 6, Name = "Seki" },
                new RoutePlace() { Id = 7, Name = "Xacmaz" },
                new RoutePlace() { Id = 8, Name = "Mingecevir" },
                new RoutePlace() { Id = 9, Name = "Xacmaz" }
            );
            modelBuilder.Entity<Route>().HasData(

                new Route() { Id = 1,FromRoutePlaceId=1,   ToRoutePlaceId=2,  Price=50, Info = "Baki" },
                new Route() { Id = 2,FromRoutePlaceId=1,   ToRoutePlaceId=3,  Price=50, Info = "Sumqayit" },
                new Route() { Id = 3,FromRoutePlaceId=1,   ToRoutePlaceId=4,  Price=50, Info = "Gence" },
                new Route() { Id = 4,FromRoutePlaceId=1,   ToRoutePlaceId=5,  Price=50, Info = "Quba" },
                new Route() { Id = 5,FromRoutePlaceId=1,   ToRoutePlaceId=6,  Price=50, Info = "Qusar" },
                new Route() { Id = 6,FromRoutePlaceId=1,   ToRoutePlaceId=7,  Price=50, Info = "Seki" },
                new Route() { Id = 7,FromRoutePlaceId=1,   ToRoutePlaceId=8,  Price=50, Info = "Xacmaz" },
                new Route() { Id = 8,FromRoutePlaceId=1,   ToRoutePlaceId=9,  Price=50, Info = "Mingecevir" }
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

            modelBuilder.Entity<Route>().
                HasOne(x => x.FromRoutePlace).
                WithMany(x => x.FromRoutes).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>().
                HasOne(x => x.ToRoutePlace).
                WithMany(x => x.ToRoutes).
                OnDelete(DeleteBehavior.Restrict);
            #endregion  // fulent api

        }
        #endregion // OnModelCreate Seeding 



    }
}