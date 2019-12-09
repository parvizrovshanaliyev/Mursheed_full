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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)
        //    //{
        //    //    optionsBuilder.UseSqlServer(
        //    //        @"Server=.\\SQLExpress; Database=Mursheed; Trusted_Connection=True;MultipleActiveResultSets=true");
        //    //}
        //    base.OnConfiguring(optionsBuilder);
        //}

        #endregion

        #region DbSets
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        /// <summary>
        /// Project entities v2 
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// Tourist
        public DbSet<Tourist> Tourists { get; set; }
        /// <summary>
        /// Guide
        /// </summary>
        public DbSet<Guide> Guides { get; set; }
        public DbSet<GuideRide> GuideRides { get; set; }
        public DbSet<GuideRoute> GuideRoutes { get; set; }
        public DbSet<GuideRideToRoute> GuideRideTos { get; set; }
        public DbSet<GuideTicket> GuideTickets { get; set; }
        public DbSet<GuideLanguage> GuideLanguages { get; set; }
        public DbSet<GuideRating> GuideRatings { get; set; }
        /// <summary>
        /// Driver
        /// </summary>
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverRide> DriverRides { get; set; }
        public DbSet<DriverRoute> DriverRoutes { get; set; }
        public DbSet<DriverRideToRoute> DriverRideToRoutes { get; set; }
        public DbSet<DriverTicket> DriverTickets { get; set; }
        public DbSet<DriverLanguage> DriverLanguages { get; set; }
        public DbSet<DriverRating> DriverRatings { get; set; }
        /// <summary>
        /// todo travel agency
        /// </summary>
        /// <param name="modelBuilder"></param>
        #endregion

        #region OnModelCreate Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed
            //    modelBuilder.Entity<Person>().HasData(

            //        new Person()
            //        {
            //            Id = 1,
            //            Firstname = "Samir",
            //            Lastname = "Karimov",
            //            FatherName = "Karimov",
            //            Email = "samir@code.edu.az"
            //        }
            //    );

            //    modelBuilder.Entity<Brand>().HasData(

            //        new Brand(){Id = 1,  Name= "Volkswagen"}
            //    );

            //    modelBuilder.Entity<Model>().HasData(

            //        new Model() {  Id = 1,  Name = "Touareg", BrandId=1},
            //        new Model() {  Id = 2,  Name = "Passat", BrandId=1}
            //    );
            //    modelBuilder.Entity<Car>().HasData(

            //        new Car(){  Id = 1,  ModelId = 1 },
            //        new Car(){  Id = 2,  ModelId = 2 }
            //    );
            //    modelBuilder.Entity<Country>().HasData(

            //        new Country() { Id = 1, Name = "Azerbaijan" }
            //    );
            //    modelBuilder.Entity<City>().HasData(

            //        new City() { Id = 1, CountryId = 1, Name = "Baki" },
            //        new City() { Id = 2, CountryId = 1, Name = "Sumqayit" },
            //        new City() { Id = 3, CountryId = 1, Name = "Gence" },
            //        new City() { Id = 4, CountryId = 1, Name = "Quba" },
            //        new City() { Id = 5, CountryId = 1, Name = "Qusar" },
            //        new City() { Id = 6, CountryId = 1, Name = "Seki" },
            //        new City() { Id = 7, CountryId = 1, Name = "Xacmaz" },
            //        new City() { Id = 8, CountryId = 1, Name = "Mingecevir" },
            //        new City() { Id = 9, CountryId = 1, Name = "Lenkeran" }
            //    );
            //modelBuilder.Entity<Driver>().HasData(

            //    new Driver()
            //    {
            //        Id = 1,
            //        Firstname = "Parviz",
            //        Lastname = "Ali",
            //        FatherName = "Rovshan",
            //        CarId=1,
            //        GovernmentalId=123456789,
            //        // secdiyi olkeye esasen seherlerden routelar yaradacaq
            //        CountryId=1
            //    },
            //    new Driver()
            //    {
            //        Id = 2,
            //        Firstname = "Aga",
            //        Lastname = "Dayi",
            //        FatherName = "Agalar",
            //        CarId = 2,
            //        GovernmentalId = 678912345,
            //        // secdiyi olkeye esasen seherlerden routelar yaradacaq
            //        CountryId = 1
            //    }

            //);
            //modelBuilder.Entity<Tourist>().HasData(

            //    new Tourist()
            //    {
            //        Id = 1,
            //        Firstname = "Heci",
            //        Lastname = "Hecili",
            //        FatherName = "Heci Oglu",
            //    }
            //);
            // demeli surucu mensub oldugu olkeye uygun seherlerden Qiymeti ile birlikde route daxil edir 
            // eyni tranzaksiya ile daxil edilen routeId ve DriverId TransporterRoute cedveline qeyd edilir
            // Musteri yeni Tourist Secdiyi Surucunun qiymetler sehifesinde  hemin surucunun yaratdigi routelara gore
            // from to selectlerini doldurmalidir 
            //modelBuilder.Entity<Route>().HasData(
            //    new Route() { Id = 1,  FromCityId = 1, ToCityId = 2, Price = 50, Info = "Baki-Sumqayit d1" },
            //    new Route() { Id = 2,  FromCityId = 1, ToCityId = 3, Price = 55, Info = "Baki-Gence d1" },
            //    new Route() { Id = 3,  FromCityId = 1, ToCityId = 4, Price = 65, Info = "Baki-Quba d1" },
            //    new Route() { Id = 4,  FromCityId = 1, ToCityId = 5, Price = 45, Info = "Baki-Qusar d1" },
            //    new Route() { Id = 5,  FromCityId = 1, ToCityId = 6, Price = 35, Info = "Baki-Seki d1" },
            //    new Route() { Id = 6,  FromCityId = 2, ToCityId = 7, Price = 25, Info = "Sumqayit-Xacmaz d1" },
            //    new Route() { Id = 7,  FromCityId = 2, ToCityId = 8, Price = 65, Info = "Sumqayit-Mingecevir d1" },
            //    new Route() { Id = 8,  FromCityId = 2, ToCityId = 9, Price = 50, Info = "Sumqayit-Lenkeran d1" },
            //    new Route() { Id = 9,  FromCityId = 1, ToCityId = 2, Price = 55, Info = "Baki-Sumqayit d2" },
            //    new Route() { Id = 10, FromCityId = 1, ToCityId = 3, Price = 45, Info = "Baki-Gence d2" },
            //    new Route() { Id = 11, FromCityId = 1, ToCityId = 4, Price = 50, Info = "Baki-Quba d2" },
            //    new Route() { Id = 12, FromCityId = 1, ToCityId = 5, Price = 55, Info = "Baki-Qusar d2" }

            //);
            //modelBuilder.Entity<TransporterRoute>().HasData(
            //    new TransporterRoute() { Id = 1, TransporterId = 1, RouteId = 1, },
            //    new TransporterRoute() { Id = 2, TransporterId = 1, RouteId = 2, },
            //    new TransporterRoute() { Id = 3, TransporterId = 1, RouteId = 3, },
            //    new TransporterRoute() { Id = 4, TransporterId = 1, RouteId = 4, },
            //    new TransporterRoute() { Id = 5, TransporterId = 1, RouteId = 5, },
            //    new TransporterRoute() { Id = 6, TransporterId = 1, RouteId = 6, },
            //    new TransporterRoute() { Id = 7, TransporterId = 1, RouteId = 7, },
            //    new TransporterRoute() { Id = 8, TransporterId = 1, RouteId = 8, },
            //    new TransporterRoute() { Id = 9, TransporterId = 2, RouteId = 9, },
            //    new TransporterRoute() { Id = 10, TransporterId = 2, RouteId = 10, },
            //    new TransporterRoute() { Id = 11, TransporterId = 2, RouteId = 11, },
            //    new TransporterRoute() { Id = 12, TransporterId = 2, RouteId = 12, }
            //);
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
            
            modelBuilder.Entity<Tourist>(entity =>
            {
                entity.ToTable("TOURIST");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e=>e.ApplicationUserId);
                entity.HasIndex(e=>e.CountryId);

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Tourists)
                    .HasForeignKey(e => e.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ApplicationUser)
                    .WithMany(e => e.Tourists)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("DRIVER");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PhotoName)
                    //.IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PhotoPath)
                    //.IsRequired()
                    .HasMaxLength(250);
                entity.Property(e => e.DriverLicenseId)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.GovernmentalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.ApplicationUserId);
                entity.HasIndex(e => e.CountryId);
                entity.HasIndex(e => e.CarId);

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Drivers)
                    .HasForeignKey(e => e.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ApplicationUser)
                    .WithMany(e => e.Drivers)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Car)
                    .WithMany(e => e.Drivers)
                    .HasForeignKey(e => e.CarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Guide>(entity =>
            {
                entity.ToTable("GUIDE");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.PhotoName)
                    //.IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PhotoPath)
                    //.IsRequired()
                    .HasMaxLength(250);
                entity.Property(e => e.GovernmentalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.ApplicationUserId);
                entity.HasIndex(e => e.CountryId);

                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Guides)
                    .HasForeignKey(e => e.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ApplicationUser)
                    .WithMany(e => e.Guides)
                    .HasForeignKey(e => e.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");
                entity.HasIndex(e => e.CountryId);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("LANGUAGE");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<DriverLanguage>(entity =>
            {
                entity.ToTable("DRIVER_LANGUAGE");

                entity.HasIndex(e => e.DriverId);
                entity.HasIndex(e => e.LanguageId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Language)
                    .WithMany(e => e.DriverLanguages)
                    .HasForeignKey(e => e.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Driver)
                    .WithMany(e => e.DriverLanguages)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<GuideLanguage>(entity =>
            {
                entity.ToTable("GUIDE_LANGUAGE");

                entity.HasIndex(e => e.GuideId);
                entity.HasIndex(e => e.LanguageId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Language)
                    .WithMany(e => e.GuideLanguages)
                    .HasForeignKey(e => e.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Guide)
                    .WithMany(e => e.GuideLanguages)
                    .HasForeignKey(e => e.GuideId)
                    .OnDelete(DeleteBehavior.Restrict);
                
            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CAR");

                entity.HasIndex(e => e.ModelId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Model)
                    .WithMany(e => e.Cars)
                    .HasForeignKey(e => e.ModelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<CarPhoto>(entity =>
            {
                entity.ToTable("CAR_PHOTO");

                entity.HasIndex(e => e.CarId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.PhotoName)
                    //.IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PhotoPath)
                    //.IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(e => e.Car)
                    .WithMany(e => e.CarPhotos)
                    .HasForeignKey(e => e.CarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRAND");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("MODEL");

                entity.HasIndex(e => e.BrandId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(e => e.Brand)
                    .WithMany(e => e.Models)
                    .HasForeignKey(e => e.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("ROUTE");

                entity.HasIndex(e => e.FromCityId);
                entity.HasIndex(e => e.ToCityId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Price)
                    .IsRequired();
                    

                entity.HasOne(e => e.FromCity)
                    .WithMany(e => e.FromRoutes)
                    .HasForeignKey(e => e.FromCityId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ToCity)
                    .WithMany(e => e.ToRoutes)
                    .HasForeignKey(e => e.ToCityId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<DriverRoute>(entity =>
            {
                entity.ToTable("DRIVER_ROUTE");

                entity.HasIndex(e => e.RouteId);
                entity.HasIndex(e => e.DriverId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Route)
                    .WithMany(e => e.DriverRoutes)
                    .HasForeignKey(e => e.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Driver)
                    .WithMany(e => e.DriverRoutes)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<GuideRoute>(entity =>
            {
                entity.ToTable("GUIDE_ROUTE");

                entity.HasIndex(e => e.RouteId);
                entity.HasIndex(e => e.GuideId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Route)
                    .WithMany(e => e.GuideRoutes)
                    .HasForeignKey(e => e.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Guide)
                    .WithMany(e => e.GuideRoutes)
                    .HasForeignKey(e => e.GuideId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<DriverRide>(entity =>
            {
                entity.ToTable("DRIVER_RIDE");

                entity.HasIndex(e => e.DriverId);
                entity.HasIndex(e => e.TouristId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Driver)
                    .WithMany(e => e.DriverRides)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Tourist)
                    .WithMany(e => e.DriverRides)
                    .HasForeignKey(e => e.TouristId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GuideRide>(entity =>
            {
                entity.ToTable("GUIDE_RIDE");

                entity.HasIndex(e => e.GuideId);
                entity.HasIndex(e => e.TouristId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Guide)
                    .WithMany(e => e.GuideRides)
                    .HasForeignKey(e => e.GuideId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Tourist)
                    .WithMany(e => e.GuideRides)
                    .HasForeignKey(e => e.TouristId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<GuideRideToRoute>(entity =>
            {
                entity.ToTable("GUIDE_RIDE_TO_ROUTE");

                entity.HasIndex(e => e.RouteId);
                entity.HasIndex(e => e.GuideRideId);
                entity.HasIndex(e => e.FromToDateId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Route)
                    .WithMany(e => e.GuideRideToRoutes)
                    .HasForeignKey(e => e.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.GuideRide)
                    .WithMany(e => e.GuideRideToRoutes)
                    .HasForeignKey(e => e.GuideRideId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.FromToDate)
                    .WithMany(e => e.GuideRideToRoutes)
                    .HasForeignKey(e => e.FromToDateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<DriverRideToRoute>(entity =>
            {
                entity.ToTable("DRIVER_RIDE_TO_ROUTE");

                entity.HasIndex(e => e.RouteId);
                entity.HasIndex(e => e.DriverRideId);
                entity.HasIndex(e => e.FromToDateId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Route)
                    .WithMany(e => e.DriverRideToRoutes)
                    .HasForeignKey(e => e.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.DriverRide)
                    .WithMany(e => e.DriverRideToRoutes)
                    .HasForeignKey(e => e.DriverRideId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.FromToDate)
                    .WithMany(e => e.DriverRideToRoutes)
                    .HasForeignKey(e => e.FromToDateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<DriverRating>(entity =>
            {
                entity.ToTable("DRIVER_RATING");

                entity.HasIndex(e => e.DriverId);
                entity.HasIndex(e => e.TouristId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Driver)
                    .WithMany(e => e.DriverRatings)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Tourist)
                    .WithMany(e => e.DriverRatings)
                    .HasForeignKey(e => e.TouristId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<GuideRating>(entity =>
            {
                entity.ToTable("GUIDE_RATING");

                entity.HasIndex(e => e.GuideId);
                entity.HasIndex(e => e.TouristId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(e => e.Guide)
                    .WithMany(e => e.GuideRatings)
                    .HasForeignKey(e => e.GuideId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Tourist)
                    .WithMany(e => e.GuideRatings)
                    .HasForeignKey(e => e.TouristId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GuideTicket>(entity =>
            {
                entity.ToTable("GUIDE_TICKET");

                entity.HasIndex(e => e.GuideRideId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.TotalPrice)
                    .IsRequired();

                entity.HasOne(e => e.GuideRide)
                    .WithMany(e => e.GuideTickets)
                    .HasForeignKey(e => e.GuideRideId)
                    .OnDelete(DeleteBehavior.Restrict);
                
            });

            modelBuilder.Entity<DriverTicket>(entity =>
            {
                entity.ToTable("DRIVER_TICKET");

                entity.HasIndex(e => e.DriverRideId);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.TotalPrice)
                    .IsRequired();

                entity.HasOne(e => e.DriverRide)
                    .WithMany(e => e.DriverTickets)
                    .HasForeignKey(e => e.DriverRideId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FromToDate>(entity =>
            {
                entity.ToTable("FROM_TO_DATE");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.StartDate)
                    .IsRequired();
                entity.Property(e => e.EndDate)
                    .IsRequired();
            });


            #endregion  // fulent api

        }
        #endregion // OnModelCreate Seeding 



    }
}
//modelBuilder.Entity<Route>().
//    HasOne(x => x.FromCity).
//    WithMany(x => x.FromRoutes).
//    OnDelete(DeleteBehavior.Restrict);

//modelBuilder.Entity<Route>().
//    HasOne(x => x.ToCity).
//    WithMany(x => x.ToRoutes).
//    OnDelete(DeleteBehavior.Restrict);

//modelBuilder.Entity<RideToRoute>(entity =>
//{
//    entity.HasIndex(e => e.RideId);

//    entity.HasIndex(e => e.RouteId);

//    entity.HasIndex(e => e.DateFromToId);

//    entity.HasOne(x => x.DateFromTo)
//        .WithMany(e => e.RideToRoutes)
//        .HasForeignKey(e => e.DateFromToId)
//        .OnDelete(DeleteBehavior.ClientSetNull)
//        .HasConstraintName("FK_RideToRoute_DateFromTo");

//    entity.HasOne(x => x.Ride)
//        .WithMany(e => e.RideToRoutes)
//        .HasForeignKey(e => e.RideId)
//        .OnDelete(DeleteBehavior.ClientSetNull)
//        .HasConstraintName("FK_RideToRoute_Ride");

//    entity.HasOne(x => x.Route)
//        .WithMany(e => e.RideToRoutes)
//        .HasForeignKey(e => e.RouteId)
//        .OnDelete(DeleteBehavior.ClientSetNull)
//        .HasConstraintName("FK_RideToRoute_Route");
//});