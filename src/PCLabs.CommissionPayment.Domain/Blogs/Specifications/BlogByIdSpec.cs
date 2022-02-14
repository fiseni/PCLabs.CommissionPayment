using Ardalis.Specification;

namespace PCLabs.CommissionPayment.Domain.Blogs.Specifications
{
    public class BlogByIdSpec : Specification<Blog>, ISingleResultSpecification
    {
        public BlogByIdSpec(Guid guid)
        {
            Query.Where(x => x.Id == guid)
                .Include(x => x.Posts);
        }
    }
}
