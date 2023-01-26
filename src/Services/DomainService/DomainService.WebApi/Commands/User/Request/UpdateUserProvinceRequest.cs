using DomainService.WebApi.Commands.User.Response;
using MediatR;

namespace DomainService.WebApi.Commands.User.Request;

public sealed record UpdateUserProvinceRequest : IRequest<UserResponse>
{
    public Guid UserId { get; init; }
    public Guid ProvinceId { get; init; }
}
