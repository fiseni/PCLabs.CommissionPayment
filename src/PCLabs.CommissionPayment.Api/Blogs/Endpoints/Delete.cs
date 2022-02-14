using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.SharedKernel.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PCLabs.CommissionPayment.Api.Blogs.Endpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<Guid>
    .WithoutResult
{
    private readonly IRepository<Blog> _repository;

    public Delete(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    [HttpDelete("/blogs/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a Blog",
        Tags = new[] { "Blogs" })
    ]
    public override async Task<ActionResult> HandleAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var blogToDelete = await _repository.GetByIdAsync(id);

        if (blogToDelete is null) return NotFound();

        await _repository.DeleteAsync(blogToDelete);

        return NoContent();
    }
}
