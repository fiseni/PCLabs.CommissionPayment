namespace PCLabs.SharedKernel.Data
{
    public abstract class InvolvedParty : BaseEntity<Guid>
    {
        public string? Name { get; protected set; }
    }
}
