using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Films.Database;
using Films.Services.Models;
using System.Threading.Tasks;

namespace Films.Services
{
    public class FilmService : IService<FilmModel>
    {
        private readonly IRepository<Film> filmRepository;
        private readonly MapperConfiguration mapperConfig;

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

        public FilmModel Get(int id)
        {
            var film = filmRepository.FindById(id);

            var mapper = this.mapperConfig.CreateMapper();
            var filmModel = mapper.Map<FilmModel>(film);

            return filmModel;
        }

        public IEnumerable<FilmModel> Get()
        {
            var films = filmRepository.Get();

            var mapper = this.mapperConfig.CreateMapper();
            var filmModels = mapper.Map<ICollection<FilmModel>>(films);

            return filmModels;
        }

        public async Task<IEnumerable<FilmModel>> GetAsync()
        {
            var films = await filmRepository.GetAsync();
            var mapper = this.mapperConfig.CreateMapper();
            var filmModels = mapper.Map<IEnumerable<FilmModel>>(films);
            return filmModels;
        }

        public void Insert(ICollection<FilmModel> filmModels)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var films = mapper.Map<ICollection<Film>>(filmModels);
            filmRepository.Insert(films);
        }

        public void Update(FilmModel filmModel)
        {
            var mapper = this.mapperConfig.CreateMapper();
            var film = mapper.Map<Film>(filmModel);
            filmRepository.Update(film);
        }

        public void Delete(int id)
        {
            filmRepository.Delete(id);
        }
    }
}
