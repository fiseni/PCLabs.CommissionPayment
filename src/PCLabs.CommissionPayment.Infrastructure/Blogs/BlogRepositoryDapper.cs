using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.CommissionPayment.Domain.Contracts;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs
{
    public class BlogRepositoryDapper : IBlogRepository
    {
        public Task<Blog?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> AddAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> UpdateAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
