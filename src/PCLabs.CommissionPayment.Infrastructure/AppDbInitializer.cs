using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCLabs.CommissionPayment.Infrastructure.Blogs;
using PCLabs.CommissionPayment.Infrastructure.Blogs.Seeds;

namespace PCLabs.CommissionPayment.Infrastructure
{
    public class AppDbInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<AppDbInitializer> _logger;

        public AppDbInitializer(
            AppDbContext dbContext,
            ILogger<AppDbInitializer> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Initialize(int retry = 0)
        {
            try
            {
                _dbContext.Database.EnsureCreated();

                if (!await _dbContext.Blogs.AnyAsync())
                {
                    _dbContext.Blogs.AddRange(BlogSeed.GetData());
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occurred while seeding the database: " + ex.Message);

                if (retry > 0)
                {
                    await Initialize(retry - 1);
                }
            }
        }
    }
}
