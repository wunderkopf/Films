using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Films.Database
{
    public class EFGenreRepository : IRepository<Genre>
    {
        private readonly ApplicationContext context;

        public EFGenreRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Genre FindById(int id)
        {
            if (id <= 0)
                return null;

            var genres = context.Genres.Where(f => f.Id == id);

            if (!genres.Any())
                return null;

            return genres.First();
        }

        public IEnumerable<Genre> Get()
        {
            var genres = context.Genres;
            return genres.ToList();
        }

        public async Task<IEnumerable<Genre>> GetAsync()
        {
            var genres = context.Genres;
            return await genres.ToListAsync();
        }

        public void Insert(ICollection<Genre> genres)
        {
            if (genres == null)
                throw new ArgumentNullException(nameof(genres));

            context.Genres.AddRange(genres);
            context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
