using Ardalis.Specification;

namespace PCLabs.CommissionPayment.Domain.Blogs.Specifications
{
    public class BlogSpec : Specification<Blog>
    {
        public BlogSpec()
        {
            Query.Include(x => x.Posts);
        }
    }
}
