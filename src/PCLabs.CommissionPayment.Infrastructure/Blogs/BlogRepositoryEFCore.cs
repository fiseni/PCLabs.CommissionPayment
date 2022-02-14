using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.CommissionPayment.Domain.Contracts;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs
{
    // Example repository to be used without specifications.
    public class BlogRepositoryEFCore : IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepositoryEFCore(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blog?> GetByIdAsync(Guid id)
        {
            var blog = await _dbContext.Blogs
                .Include(x => x.Posts)
                .SingleOrDefaultAsync(x => x.Id == id);

            return blog;
        }

        public async Task<List<Blog>> ListAsync()
        {
            var blogs = await _dbContext.Blogs
                .Include(x => x.Posts)
                .ToListAsync();

            return blogs;
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            Guard.Against.Null(blog, nameof(blog));

            _dbContext.Blogs.Add(blog);
            await _dbContext.SaveChangesAsync();

            return blog;
        }

        public async Task<Blog> UpdateAsync(Blog blog)
        {
            Guard.Against.Null(blog, nameof(blog));

            // Not necessary. We'll discuss the change tracker.
            _dbContext.Blogs.Update(blog);

            await _dbContext.SaveChangesAsync();

            return blog;
        }

        public async Task DeleteAsync(Blog blog)
        {
            Guard.Against.Null(blog, nameof(blog));

            _dbContext.Blogs.Remove(blog);

            await _dbContext.SaveChangesAsync();
        }
    }
}
