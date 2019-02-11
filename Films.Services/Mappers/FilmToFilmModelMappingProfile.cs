using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Films.Database;
using Films.Services.Models;

namespace Films.Services.Mappers
{
    public class FilmToFilmModelMappingProfile : Profile
    {
        public FilmToFilmModelMappingProfile()
        {
            CreateMap<Film, FilmModel>()
               .ForMember(d => d.Genres, opt => opt.MapFrom(s => s.FilmGenre.Select(p => p.GenreId)));

            CreateMap<FilmModel, Film>()
            .AfterMap((s, d) =>
            {
                d.FilmGenre = new List<FilmGenre>();
                foreach (var genreId in s.Genres)
                    d.FilmGenre.Add(new FilmGenre { GenreId = genreId });
            });
        }
    }
}
