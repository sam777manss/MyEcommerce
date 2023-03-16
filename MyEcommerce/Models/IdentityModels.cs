using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyEcommerce.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string fname { get; set; }
        public string lname { get; set; }
        //public DateTime dob { get; set; }
        //public string gender { get; set; }

        //public string address { get; set; }
    }

    public class ProductAdd
        {
        [Key]
        public int id { get; set; }
        
        public string name { get; set; }
        
        public string prize { get; set; }
        
        public string availability { get; set; }
        
        public string description { get; set; }
        
        public string details { get; set; }
        
        public string flag { get; set; }

        public string imageUrl { get; set; }
        
        public string address { get; set; }

        public string categories { get; set; }
    }

    public class UserCard
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string totalprize { get; set; }
        public string flag { get; set; }
        public string imgcardUrl { get; set; }
        public string description { get; set; }
        public string userId { get; set; }
        public string details { get; set; }
        public string address { get; set; }
        public string quantity { get; set; }
    }
    public class ItemToBeShipped
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string totalprize { get; set; }
        public string flag { get; set; }
        public string imgcardUrl { get; set; }
        public string description { get; set; }
        public string userId { get; set; }
        public string details { get; set; }
        public string address { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<MyEcommerce.Models.ProductAdd> ProductAdds { get; set; }
        public System.Data.Entity.DbSet<MyEcommerce.Models.UserCard> UserCards { get; set; }
        public System.Data.Entity.DbSet<MyEcommerce.Models.ItemToBeShipped> itemToBeShippeds { get; set; }

    }
}