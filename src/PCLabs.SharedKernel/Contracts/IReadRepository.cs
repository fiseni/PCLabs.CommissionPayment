using Ardalis.Specification;

namespace PCLabs.SharedKernel.Contracts
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
        Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);
        Task<T?> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);

        Task<TResult?> ProjectToSingleOrDefaultAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken);
        Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<T> specification, CancellationToken cancellationToken);
        Task<List<TResult>> ProjectToListAsync<TResult>(CancellationToken cancellationToken);
    }
}
