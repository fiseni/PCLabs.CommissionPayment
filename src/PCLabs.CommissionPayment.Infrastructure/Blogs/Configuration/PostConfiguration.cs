using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCLabs.CommissionPayment.Domain.Blogs;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post));

            builder.HasKey(p => p.Id);
        }
    }
}
