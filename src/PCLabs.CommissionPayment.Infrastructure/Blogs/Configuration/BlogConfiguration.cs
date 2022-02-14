using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCLabs.CommissionPayment.Domain.Blogs;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable(nameof(Blog));

            builder.Metadata.FindNavigation(nameof(Blog.Posts))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(b => b.Id);
        }
    }
}
