using System.Collections.Generic;
using AutoMapper;
using Films.Database;
using Films.Services.Models;
using System.Threading.Tasks;

namespace Films.Services
{
    public class FilmService : IService<FilmModel>
    {
        private readonly IRepository<Film> filmRepository;
        private readonly IMapper mapper;

        public FilmService(IRepository<Film> filmRepository, IMapper mapper)
        {
            this.filmRepository = filmRepository;
            this.mapper = mapper;
        }

        public FilmModel Get(int id)
        {
            var film = filmRepository.FindById(id);
            var filmModel = mapper.Map<FilmModel>(film);
            return filmModel;
        }

        public IEnumerable<FilmModel> Get()
        {
            var films = filmRepository.Get();
            var filmModels = mapper.Map<ICollection<FilmModel>>(films);
            return filmModels;
        }

        public async Task<IEnumerable<FilmModel>> GetAsync()
        {
            var films = await filmRepository.GetAsync();
            var filmModels = mapper.Map<IEnumerable<FilmModel>>(films);
            return filmModels;
        }

        public void Insert(ICollection<FilmModel> filmModels)
        {
            var films = mapper.Map<ICollection<Film>>(filmModels);
            filmRepository.Insert(films);
        }

        public void Update(FilmModel filmModel)
        {
            var film = mapper.Map<Film>(filmModel);
            filmRepository.Update(film);
        }

        public void Delete(int id)
        {
            filmRepository.Delete(id);
        }
    }
}
