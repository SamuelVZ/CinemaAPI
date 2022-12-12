using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using System.Security.Cryptography.Xml;

namespace CinemaAPI.Profiles {
    public class MovieProfile : Profile {
        public MovieProfile() {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, AddMovieDto>().ReverseMap();
            CreateMap<Movie, DisplayMoviesDto>().ReverseMap();
            //CreateMap<IQueryable, FindMovies>().ReverseMap();
        }
    }
}
