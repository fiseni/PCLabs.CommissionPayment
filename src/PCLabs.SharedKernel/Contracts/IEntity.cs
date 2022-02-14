namespace PCLabs.SharedKernel.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
