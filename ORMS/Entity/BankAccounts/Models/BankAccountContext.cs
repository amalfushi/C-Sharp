using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Models
{
    public class BankAccountContext : DbContext
    {
        public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
    }
}