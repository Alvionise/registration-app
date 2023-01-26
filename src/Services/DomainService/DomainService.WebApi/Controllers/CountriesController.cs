using System.Net;
using DomainService.WebApi.Queries.Country.Requests;
using DomainService.WebApi.Queries.Country.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(IEnumerable<CountryQueryResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetCountries()
    {
        var response = await _mediator.Send(new GetCountryQueryRequest());
        return Ok(response);
    }
}
