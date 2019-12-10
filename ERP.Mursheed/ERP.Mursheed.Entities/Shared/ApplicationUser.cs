using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ERP.Mursheed.Entities.Shared
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Drivers = new HashSet<Driver>();
            Guides = new HashSet<Guide>();
            Tourists = new HashSet<Tourist>();
        }
        //public int PersonId { get; set; }
        public bool Status { get; set; }

        //[ForeignKey("PersonId")]
        //public virtual Person Person { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        /// <summary>
        /// TOURIST, GUIDE, DRIVER
        /// </summary>
        public virtual ICollection<Tourist> Tourists { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Guide> Guides { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
