using System;
using Films.Database;
using Films.Services.Models;
using AutoMapper;

namespace Films.Services.Mappers
{
    public class GenreToGenreModelMappingProfile : Profile
    {
        public GenreToGenreModelMappingProfile()
        {
            CreateMap<Genre, GenreModel>();
            CreateMap<GenreModel, Genre>();
        }
    }
}
