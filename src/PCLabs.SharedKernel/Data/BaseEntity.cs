using PCLabs.SharedKernel.Contracts;

namespace PCLabs.SharedKernel.Data
{
    public abstract class BaseEntity<T> : IEntity<T>, ISoftDelete, IAuditableEntity where T : struct
    {
        public T Id { get; protected set; } = default(T);

        public bool IsDeleted { get; protected set; }

        public DateTime? AuditCreatedTime { get; protected set; }
        public string? AuditCreatedByUserId { get; protected set; }
        public string? AuditCreatedByUsername { get; protected set; }
        public DateTime? AuditModifiedTime { get; protected set; }
        public string? AuditModifiedByUserId { get; protected set; }
        public string? AuditModifiedByUsername { get; protected set; }
    }
}
