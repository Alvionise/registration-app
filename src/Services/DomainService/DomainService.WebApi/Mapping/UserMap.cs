using AutoMapper;
using DomainService.Core.Domain.Entities;
using DomainService.WebApi.Commands.User.Request;
using DomainService.WebApi.Commands.User.Response;

namespace DomainService.WebApi.Mapping;
internal class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<CreateUserRequest, User>()
            .ForMember(x => x.Email, m => m.MapFrom(f => f.Login))
            .ForMember(x => x.Password, m => m.MapFrom(f => f.Password))
            .ForMember(x => x.IsAgreeWorkForFood, m => m.MapFrom(f => f.IsAgreeWorkForFood));

        CreateMap<User, UserResponse>()
            .ForMember(x => x.UserId, m => m.MapFrom(f => f.Id));
    }
}
