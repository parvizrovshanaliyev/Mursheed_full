using System;
using System.Threading.Tasks;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Mursheed.ORMV2
{
    public class DbInitializer
    {

        private readonly IUnitOfWork _unitOfWork;

        public DbInitializer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public static async Task Seed(IServiceProvider serviceProvider, IConfiguration configuration)
        {

            //Adding custom Roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { StaticRoles.AdminRole,
                                   StaticRoles.MemberRole,
                                   StaticRoles.ModeratorRole,
                                   StaticRoles.ViewAllDocuments,
                                   StaticRoles.CreateDocInfo,
                                   StaticRoles.CreateDocVisa,
                                   StaticRoles.CreateDoc,
                                   StaticRoles.SupplierPerson,
                                   StaticRoles.StoreKeeper
            };

            // creating the roles and seeding them to the database
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }

            //var configBuilder= new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true);
            //configuration = configBuilder.Build();


            //creating admin 
            var user = await userManager.FindByEmailAsync(configuration.GetSection("AdminSettings")["Email"]);
            if (user == null)
            {
                var admin = new ApplicationUser()
                {
                    Email = configuration.GetSection("AdminSettings")["Email"],
                    UserName = configuration.GetSection("AdminSettings")["Username"],
                    Status = true
                    // todo
                };

                var userPass = configuration.GetSection("AdminSettings")["Password"];

                var createAdminResult = await userManager.CreateAsync(admin, userPass);

                if (createAdminResult.Succeeded)
                {
                    // here we assign the new user "Admin" role
                    await userManager.AddToRolesAsync(admin, roleNames);
                }
            }

        }

    }
}
