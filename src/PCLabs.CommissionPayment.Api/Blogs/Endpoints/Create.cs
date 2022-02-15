using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCLabs.CommissionPayment.Api.Blogs.Models;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.SharedKernel.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PCLabs.CommissionPayment.Api.Blogs.Endpoints;

public class Create : EndpointBaseAsync
    .WithRequest<BlogCreateDto>
    .WithActionResult<BlogDto>
{
    private readonly IRepository<Blog> _repository;
    private readonly IMapper _mapper;

    public Create(IRepository<Blog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost("/blogs")]
    [SwaggerOperation(
        Summary = "Creates a new Blog",
        Tags = new[] { "Blogs" })
    ]
    public override async Task<ActionResult<BlogDto>> HandleAsync(
        BlogCreateDto request,
        CancellationToken cancellationToken)
    {
        if (request is null) return BadRequest();

        var newBlog = new Blog(request.Name!);

        var blog = await _repository.AddAsync(newBlog, cancellationToken);

        var response = _mapper.Map<BlogDto>(blog);

        return Ok(response);
    }
}
