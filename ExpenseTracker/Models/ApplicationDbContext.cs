using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //Transaction
        public DbSet<Transaction> Transactions { get; set; }
        //Category
        public DbSet<Category> Categories { get; set; }
    }
}