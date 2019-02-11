using System.Collections.Generic;
using AutoMapper;
using Films.Database;
using Films.Services.Models;
using System.Threading.Tasks;

namespace Films.Services
{
    public class GenreService : IService<GenreModel>
    {
        private readonly IRepository<Genre> genreRepository;
        private readonly IMapper mapper;

        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public GenreModel Get(int id)
        {
            var genre = genreRepository.FindById(id);
            var genreModel = mapper.Map<GenreModel>(genre);
            return genreModel;
        }

        public IEnumerable<GenreModel> Get()
        {
            var genres = genreRepository.Get();
            var genreModels = mapper.Map<ICollection<GenreModel>>(genres);
            return genreModels;
        }

        public async Task<IEnumerable<GenreModel>> GetAsync()
        {
            var genres = await genreRepository.GetAsync();
            var genreModels = mapper.Map<IEnumerable<GenreModel>>(genres);
            return genreModels;
        }

        public void Insert(ICollection<GenreModel> genreModels)
        {
            var genres = mapper.Map<ICollection<Genre>>(genreModels);
            genreRepository.Insert(genres);
        }

        public void Update(GenreModel genreModel)
        {
            var genre = mapper.Map<Genre>(genreModel);
            genreRepository.Update(genre);
        }

        public void Delete(int id)
        {
            genreRepository.Delete(id);
        }
    }
}
