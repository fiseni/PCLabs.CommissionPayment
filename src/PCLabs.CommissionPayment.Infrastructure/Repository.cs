using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCLabs.CommissionPayment.Infrastructure.Blogs;
using PCLabs.SharedKernel.Contracts;

namespace PCLabs.CommissionPayment.Infrastructure
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T?> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
        }

        public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
