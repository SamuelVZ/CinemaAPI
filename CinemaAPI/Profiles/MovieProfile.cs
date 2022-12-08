using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles {
    public class MovieProfile : Profile {
        public MovieProfile() {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, AddMovieDto>().ReverseMap();
        }
    }
}
