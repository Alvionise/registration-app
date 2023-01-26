using System.Net;
using DomainService.WebApi.Commands.User.Request;
using DomainService.WebApi.Commands.User.Response;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateUserRequest> _validatorCreateUserRequest;
    private readonly IValidator<UpdateUserProvinceRequest> _validatorUpdateUSerProvince;

    public UsersController(IMediator mediator, IValidator<CreateUserRequest> validatorCreateUserRequest, IValidator<UpdateUserProvinceRequest> validatorUpdateUSerProvince)
    {
        _mediator = mediator;
        _validatorCreateUserRequest = validatorCreateUserRequest;
        _validatorUpdateUSerProvince = validatorUpdateUSerProvince;
    }

    /// <summary>
    /// Create User entity
    /// </summary>
    /// <param name="request">Creation request</param>
    /// <returns><see cref="ActionResult"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _validatorCreateUserRequest.ValidateAsync(request);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        var response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Update user with Province
    /// </summary>
    /// <param name="request">User province relation</param>
    /// <returns><see cref="ActionResult"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateUserProvince([FromBody] UpdateUserProvinceRequest request)
    {
        var result = await _validatorUpdateUSerProvince.ValidateAsync(request);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
