using AutoMapper;
using PCLabs.CommissionPayment.Domain.Blogs;

namespace PCLabs.CommissionPayment.Api.Blogs.Models;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Post, PostDto>();
        CreateMap<Blog, BlogDto>();
    }
}
