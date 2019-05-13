using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ReceiptWebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}