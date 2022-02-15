namespace PCLabs.CommissionPayment.Api.Blogs.Models;

public record BlogUpdateDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
