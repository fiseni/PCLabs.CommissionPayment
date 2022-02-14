using Ardalis.Specification;

namespace PCLabs.CommissionPayment.Domain.Blogs.Specifications
{
    public class BlogByNameSpec : Specification<Blog>, ISingleResultSpecification
    {
        public BlogByNameSpec(string name)
        {
            Query.Where(x=>x.Name.Equals(name))
                .Include(x => x.Posts);
        }
    }
}
