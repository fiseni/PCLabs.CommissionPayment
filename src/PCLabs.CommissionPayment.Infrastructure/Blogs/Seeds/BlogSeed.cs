using PCLabs.CommissionPayment.Domain.Blogs;

namespace PCLabs.CommissionPayment.Infrastructure.Blogs.Seeds
{
    public static class BlogSeed
    {
        public static List<Blog> GetData()
        {
            var blogs = new List<Blog>();

            for (int i = 0; i < 10; i++)
            {
                var blog = new Blog($"Name {i}");
                blog.AddPost(new Post($"Post {i}_1"));
                blog.AddPost(new Post($"Post {i}_2"));
                blog.AddPost(new Post($"Post {i}_3"));

                blogs.Add(blog);
            }

            return blogs;
        }
    }
}
