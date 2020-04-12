using AutoMapper;
using Domain.Models;
using Domain.Models.Auth;
using Repository.Entities;

namespace API.DI.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserModel, User>();
            CreateMap<UserAddModel, User>();
            CreateMap<User, UserModel>().ForMember(d => d.UserAuths, o => o.MapFrom(c => c.UserAuths));
            CreateMap<UserModel, UserTokenModel>();


            CreateMap<UserAuthModel, UserAuth>();
            CreateMap<UserAuth, UserAuthModel>();
           
        }
    }
}
