using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, AddUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
