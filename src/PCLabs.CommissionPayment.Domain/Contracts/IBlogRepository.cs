using PCLabs.CommissionPayment.Domain.Blogs;

namespace PCLabs.CommissionPayment.Domain.Contracts
{
    public interface IBlogRepository
    {
        Task<Blog?> GetByIdAsync(Guid id);
        Task<List<Blog>> ListAsync();
        Task<Blog> AddAsync(Blog blog);
        Task<Blog> UpdateAsync(Blog blog);
        Task DeleteAsync(Blog blog);
    }
}
