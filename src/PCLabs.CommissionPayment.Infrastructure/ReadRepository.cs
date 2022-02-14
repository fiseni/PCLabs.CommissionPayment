using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PCLabs.CommissionPayment.Infrastructure.Blogs;
using PCLabs.SharedKernel.Contracts;

namespace PCLabs.CommissionPayment.Infrastructure
{
    public class ReadRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfigurationProvider _configurationProvider;

        public ReadRepository(AppDbContext dbContext, IMapper mapper)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _configurationProvider = mapper.ConfigurationProvider;
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

        public async Task<TResult?> ProjectToSingleOrDefaultAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await ApplySpecification(specification)
                .ProjectTo<TResult>(_configurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await ApplySpecification(specification)
                .ProjectTo<TResult>(_configurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<TResult>> ProjectToListAsync<TResult>(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>()
                .ProjectTo<TResult>(_configurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
