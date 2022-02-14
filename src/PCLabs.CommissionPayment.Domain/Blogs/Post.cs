using Ardalis.GuardClauses;
using PCLabs.SharedKernel.Data;
using System.Diagnostics.CodeAnalysis;

namespace PCLabs.CommissionPayment.Domain.Blogs
{
    public class Post : BaseEntity<Guid>
    {
        public string Title { get; private set; }
        public Guid BlogId { get; private set; }

        public Post(string title)
        {
            Update(title);
        }

        [MemberNotNull(nameof(Title))]
        public void Update(string title)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));

            Title = title;
        }
    }
}
