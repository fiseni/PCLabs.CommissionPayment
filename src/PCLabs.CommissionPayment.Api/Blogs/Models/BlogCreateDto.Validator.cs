using FluentValidation;

namespace PCLabs.CommissionPayment.Api.Blogs.Models
{
    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
