using Microsoft.EntityFrameworkCore;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.CommissionPayment.Infrastructure.Blogs.Configuration;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs => Set<Blog>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogConfiguration).Assembly);
        }
    }
}
