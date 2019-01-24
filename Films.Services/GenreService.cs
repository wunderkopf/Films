using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Films.Database;
using Films.Services.Models;

namespace Films.Services
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> GetGenres();
        GenreModel GetGenre(int id);
        void InsertGenres(ICollection<GenreModel> genreModels);
        void UpdateGenre(GenreModel genreModel);
        void DeleteGenre(int id);
    }

    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> genreRepository;
        private readonly MapperConfiguration mapperConfig;

        public GenreService(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;

            this.mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreModel>();
                cfg.CreateMap<GenreModel, Genre>();
            });
        }

        public GenreModel GetGenre(int id)
        {
            var genre = genreRepository.FindById(id);

            var mapper = this.mapperConfig.CreateMapper();
            var genreModel = mapper.Map<GenreModel>(genre);

            return genreModel;
        }

        public IEnumerable<GenreModel> GetGenres()
        {
            var genres = genreRepository.Get();

            var mapper = this.mapperConfig.CreateMapper();
            var genreModels = mapper.Map<ICollection<GenreModel>>(genres);

            return genreModels;
        }

        public void InsertGenres(ICollection<GenreModel> genreModels)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var genres = mapper.Map<ICollection<Genre>>(genreModels);
            genreRepository.Insert(genres);
        }

        public void UpdateGenre(GenreModel genreModel)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var genre = mapper.Map<Genre>(genreModel);
            genreRepository.Update(genre);
        }

        public void DeleteGenre(int id)
        {
            genreRepository.Delete(id);
        }
    }
}
