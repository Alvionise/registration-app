using System.Net;
using DomainService.WebApi.Queries.Province.Requests;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainService.WebApi.Queries.Province.Responses;

namespace DomainService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvincesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<GetProvinceByContryQueryRequest> _validatorGetCountryUserRequest;

    public ProvincesController(IMediator mediator, IValidator<GetProvinceByContryQueryRequest> validatorGetCountryUserRequest)
    {
        _mediator = mediator;
        _validatorGetCountryUserRequest = validatorGetCountryUserRequest;
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(IEnumerable<GetProvinceByCountryQueryResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetProvincesByCountryId(Guid countryId)
    {
        var request = new GetProvinceByContryQueryRequest { CountryId = countryId };
        var validationResult = await _validatorGetCountryUserRequest.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }

        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
