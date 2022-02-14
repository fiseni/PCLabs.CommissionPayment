using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCLabs.CommissionPayment.Api.Blogs.Models;
using PCLabs.CommissionPayment.Domain.Blogs;
using PCLabs.CommissionPayment.Domain.Blogs.Specifications;
using PCLabs.SharedKernel.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PCLabs.CommissionPayment.Api.Blogs.Endpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<List<BlogDto>>
{
    private readonly IReadRepository<Blog> _readRepository;
    private readonly IMapper _mapper;

    public List(IReadRepository<Blog> readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    [HttpGet("/blogs")]
    [SwaggerOperation(
        Summary = "Gets a list of all Blogs",
        Tags = new[] { "Blogs" })
    ]
    public override async Task<ActionResult<List<BlogDto>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var spec = new BlogSpec();
        var blogs = await _readRepository.ListAsync(spec, cancellationToken);

        var response = _mapper.Map<List<BlogDto>>(blogs);

        return Ok(response);
    }

    // Alternatively we can project directly to the results, without utilizing the domain model.
    //public async Task<ActionResult<List<BlogDto>>> HandleAlternativeAsync(
    //    CancellationToken cancellationToken = default)
    //{
    //    var spec = new BlogSpec();
    //    var response = await _readRepository.ProjectToListAsync<BlogDto>(spec, cancellationToken);

    //    return Ok(response);
    //}
}
