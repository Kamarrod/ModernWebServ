using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Auth
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<ReturnUserDto, User>();
            CreateMap<User, ReturnUserDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
        }
    }
}
