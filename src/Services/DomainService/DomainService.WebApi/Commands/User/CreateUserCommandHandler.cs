using AutoMapper;
using DomainService.Dal;
using DomainService.Dal.Abstractions;
using DomainService.WebApi.Commands.User.Request;
using DomainService.WebApi.Commands.User.Response;
using MediatR;

namespace DomainService.WebApi.Commands.User;
public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, UserResponse>
{
    private readonly ICommandRepository<Core.Domain.Entities.User, Guid> _commandRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;

    public CreateUserCommandHandler(ICommandRepository<Core.Domain.Entities.User, Guid> commandRepository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _commandRepository.AddAsync(_mapper.Map<Core.Domain.Entities.User>(request), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UserResponse>(response);
    }
}
