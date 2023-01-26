using DomainService.ValueObjects.Email;
using DomainService.ValueObjects.Password;
using DomainService.WebApi.Commands.User.Response;
using MediatR;

namespace DomainService.WebApi.Commands.User.Request;

public sealed record CreateUserRequest : IRequest<UserResponse>
{
    public Email Login { get; init; } = null!;
    public Password Password { get; init; } = null!;
    public Password ConfirmPassword { get; init; } = null!;
    public bool IsAgreeWorkForFood { get; init; }
}
