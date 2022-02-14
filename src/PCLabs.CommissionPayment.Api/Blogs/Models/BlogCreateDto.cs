namespace PCLabs.CommissionPayment.Api.Blogs.Models;

public record BlogCreateDto
{
    public string Name { get; set; } = default(string)!;
}
