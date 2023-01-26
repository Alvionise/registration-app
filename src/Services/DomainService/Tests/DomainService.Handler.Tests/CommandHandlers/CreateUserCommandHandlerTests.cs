using AutoMapper;
using DomainService.Core.Domain.Entities;
using DomainService.Dal.Abstractions;
using DomainService.Dal;
using DomainService.ValueObjects.Email;
using DomainService.ValueObjects.Password;
using DomainService.WebApi.Commands.User;
using Moq;
using DomainService.WebApi.Commands.User.Request;

namespace DomainService.Handler.Tests.CommandHandlers;

/// <summary>
/// Test for User command handler for example
/// </summary>
public class CreateUserCommandHandlerTests
{
    private readonly Mock<ICommandRepository<User, Guid>> _commandRepository = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<IUnitOfWork<AppDbContext>> _unitOfWork = new();
    private readonly CreateUserCommandHandler _commandHandler;
    private readonly IFixture _fixture;

    public CreateUserCommandHandlerTests()
    {
        _commandHandler = new CreateUserCommandHandler(_commandRepository.Object, _mapper.Object, _unitOfWork.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Handle_WhenUserIsValid_ShouldCreateUser()
    {
        // Arrange
        var password = _fixture.Create<Password>();

        var request = _fixture.Build<CreateUserRequest>()
            .With(x => x.IsAgreeWorkForFood, true)
            .With(x => x.Password, password)
            .With(x => x.ConfirmPassword, password)
            .With(x => x.Login, _fixture.Create<Email>())
            .Create();

        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await _commandHandler.Handle(request, cancellationToken);

        // Assert
        _commandRepository.Verify(r => r.AddAsync(
                It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    // and etc. cases
}
