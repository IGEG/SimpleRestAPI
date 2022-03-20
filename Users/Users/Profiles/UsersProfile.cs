using AutoMapper;
using Users.MOdels;
using Users.ModelsMapper;

namespace Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserMapper>();
            CreateMap<CreateUserMapper, User>();
            CreateMap<UpdateUserMapper, User>();
            CreateMap<User, UpdateUserMapper>();
        }
    }
}