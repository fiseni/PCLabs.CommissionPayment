using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCLabs.CommissionPayment.Api.Blogs.Models;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.CommissionPayment.Domain.Blogs.Specifications;
using PCLabs.SharedKernel.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PCLabs.CommissionPayment.Api.Blogs.Endpoints;

public class GetById : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<BlogDto>
{
    private readonly IReadRepository<Blog> _readRepository;
    private readonly IMapper _mapper;

    public GetById(IReadRepository<Blog> readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    [HttpGet("/blogs/{id}")]
    [SwaggerOperation(
        Summary = "Gets a single Blog",
        Tags = new[] { "Blogs" })
    ]
    public override async Task<ActionResult<BlogDto>> HandleAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var spec = new BlogByIdSpec(id);
        var blog = await _readRepository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog is null) return NotFound();

        var response = _mapper.Map<BlogDto>(blog);

        return Ok(response);
    }

    // Alternatively we can project directly to the results, without utilizing the domain model.
    //public async Task<ActionResult<BlogDto>> HandleAlternativeAsync(
    //    Guid id,
    //    CancellationToken cancellationToken = default)
    //{
    //    var spec = new BlogByIdSpec(id);
    //    var response = await _readRepository.ProjectToFirstOrDefaultAsync<BlogDto>(spec, cancellationToken);

    //    if (response is null) return NotFound();

    //    return Ok(response);
    //}
}
