using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) {}

        public DbSet<Review> Reviews { get; set; }
    }
}