using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Films.Database;
using Films.Services.Models;

namespace Films.Services
{
    public interface IFilmService
    {
        IEnumerable<FilmModel> GetFilms();
        FilmModel GetFilm(int id);
        void InsertFilms(ICollection<FilmModel> filmModels);
        void UpdateFilm(FilmModel filmModel);
        void DeleteFilm(int id);
    }

    public class FilmService : IFilmService
    {
        private readonly IRepository<Film> filmRepository;
        private MapperConfiguration mapperConfig;

        public FilmService(IRepository<Film> filmRepository)
        {
            this.filmRepository = filmRepository;

            this.mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Film, FilmModel>()
                .ForMember(d => d.Genres, opt => opt.MapFrom(s => s.FilmGenre.Select(p => p.GenreId)));

                cfg.CreateMap<FilmModel, Film>()
                .AfterMap((s, d) =>
                {
                    d.FilmGenre = new List<FilmGenre>();
                    foreach (var genreId in s.Genres)
                        d.FilmGenre.Add(new FilmGenre { GenreId = genreId } );
                });
            });
        }

        public FilmModel GetFilm(int id)
        {
            var film = filmRepository.FindById(id);

            var mapper = this.mapperConfig.CreateMapper();
            var filmModel = mapper.Map<FilmModel>(film);

            return filmModel;
        }

        public IEnumerable<FilmModel> GetFilms()
        {
            var films = filmRepository.Get();

            var mapper = this.mapperConfig.CreateMapper();
            var filmModels = mapper.Map<ICollection<FilmModel>>(films);

            return filmModels;
        }

        public void InsertFilms(ICollection<FilmModel> filmModels)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var films = mapper.Map<ICollection<Film>>(filmModels);
            filmRepository.Insert(films);
        }

        public void UpdateFilm(FilmModel filmModel)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var film = mapper.Map<Film>(filmModel);
            filmRepository.Update(film);
        }

        public void DeleteFilm(int id)
        {
            filmRepository.Delete(id);
        }
    }
}
