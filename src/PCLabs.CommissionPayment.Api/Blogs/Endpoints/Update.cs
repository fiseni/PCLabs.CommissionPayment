using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCLabs.CommissionPayment.Api.Blogs.Models;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.SharedKernel.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PCLabs.CommissionPayment.Api.Blogs.Endpoints;
public class Update : EndpointBaseAsync
    .WithRequest<BlogUpdateDto>
    .WithActionResult<BlogDto>
{
    private readonly IRepository<Blog> _repository;
    private readonly IMapper _mapper;

    public Update(IRepository<Blog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPut("/blogs")]
    [SwaggerOperation(
        Summary = "Updates a Blog",
        Tags = new[] { "Blogs" })
    ]
    public override async Task<ActionResult<BlogDto>> HandleAsync(
        BlogUpdateDto request,
        CancellationToken cancellationToken)
    {
        if (request is null) return BadRequest();

        var existingBlog = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (existingBlog is null) return NotFound();

        existingBlog.Update(request.Name);

        await _repository.UpdateAsync(existingBlog, cancellationToken);

        var response = _mapper.Map<BlogDto>(existingBlog);

        return Ok(response);
    }
}
