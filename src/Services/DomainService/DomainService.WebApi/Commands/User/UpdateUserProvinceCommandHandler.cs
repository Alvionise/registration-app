using DomainService.Core.Domain.Entities;
using DomainService.Dal.Abstractions;
using DomainService.Dal;
using DomainService.WebApi.Commands.User.Request;
using DomainService.WebApi.Commands.User.Response;
using MediatR;

namespace DomainService.WebApi.Commands.User;
internal class UpdateUserProvinceCommandHandler : IRequestHandler<UpdateUserProvinceRequest, UserResponse>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IQueryRepository<Province, Guid> _provinceQueryRepository;
    private readonly ICommandRepository<Core.Domain.Entities.User, Guid> _userCommandRepository;

    public UpdateUserProvinceCommandHandler(IUnitOfWork<AppDbContext> unitOfWork,
        IQueryRepository<Province, Guid> provinceQueryRepository,
        ICommandRepository<Core.Domain.Entities.User, Guid> userCommandRepository)
    {
        _unitOfWork = unitOfWork;
        _provinceQueryRepository = provinceQueryRepository;
        _userCommandRepository = userCommandRepository;
    }

    public async Task<UserResponse> Handle(UpdateUserProvinceRequest request, CancellationToken cancellationToken)
    {
        var province = await _provinceQueryRepository.FirtOrDefaultAsync(x => x.Id == request.ProvinceId, cancellationToken);
        if (province == null)
        {
            throw new KeyNotFoundException($"Province with id {request.ProvinceId} not found");
        }

        var user = await _userCommandRepository.FirtOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id {request.UserId} not found");
        }

        user.SetProvince(province);

        _userCommandRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new UserResponse { UserId = user.Id };
    }
}
