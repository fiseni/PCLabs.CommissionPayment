namespace PCLabs.CommissionPayment.Api.Blogs.Models;

public record BlogDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default(string)!;

    public List<PostDto> Posts { get; set; } = new();
}
