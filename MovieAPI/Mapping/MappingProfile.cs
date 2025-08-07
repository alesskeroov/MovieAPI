using AutoMapper;
using MovieAPI.Dtos;
using MovieAPI.Entities;

namespace MovieAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
