using Ardalis.GuardClauses;
using PCLabs.SharedKernel.Contracts;
using PCLabs.SharedKernel.Data;
using System.Diagnostics.CodeAnalysis;

namespace PCLabs.CommissionPayment.Domain.Blogs
{
    public class Blog : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }

        private readonly List<Post> _posts = new();
        public IEnumerable<Post> Posts => _posts.AsEnumerable();

        public Blog(string name)
        {
            Update(name);
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));

            Name = name;
        }

        public Post AddPost(Post post)
        {
            Guard.Against.Null(post, nameof(post));

            var existingPost = Posts.FirstOrDefault(x => x.Title == post.Title);
            if (existingPost is not null)
            {
                throw new ArgumentException("The provided post already exists!");
            }

            _posts.Add(post);
            return post;
        }

        public void DeletePost(Guid postId)
        {
            var post = Posts.FirstOrDefault(x => x.Id == postId);
            Guard.Against.NotFound(postId, post, nameof(post));

            _posts.Remove(post);
        }
    }
}
