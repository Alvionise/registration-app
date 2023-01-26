namespace DomainService.WebApi.Commands.User.Response;

public record UserResponse
{
    public Guid UserId { get; init; }
}
