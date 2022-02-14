using FluentValidation;

namespace PCLabs.CommissionPayment.Api.Blogs.Models
{
    public class BlogUpdateDtoValidator : AbstractValidator<BlogUpdateDto>
    {
        public BlogUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
