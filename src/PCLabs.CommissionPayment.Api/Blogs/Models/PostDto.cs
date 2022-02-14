namespace PCLabs.CommissionPayment.Api.Blogs.Models;

public record PostDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}
