using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Films.Database
{
    public class EFFilmRepository : IRepository<Film>
    {
        private readonly ApplicationContext context;

        public EFFilmRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Film FindById(int id)
        {
            if (id <= 0)
                return null;

            var films = context.Films
            //.Where(f => f.Id == id)
            .Include(f => f.FilmGenre)
            //.ThenInclude(fg => fg.Genre)
            .Where(f => f.Id == id).ToList();

            if (!films.Any())
                return null;

            return films.First();
        }

        public IEnumerable<Film> Get()
        {
            var films = context.Films
            .Include(fg => fg.FilmGenre)
            .ThenInclude(fg => fg.Genre);

            return films.ToList();
        }

        public void Insert(ICollection<Film> films)
        {
            if (films == null)
                throw new ArgumentNullException(nameof(films));

            context.Films.AddRange(films);
            context.SaveChanges();
        }

        public void Update(Film film)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var film = FindById(id);
            if (film != null)
            {
                context.FilmsGenres.RemoveRange(film.FilmGenre);
                context.Films.Remove(film);
                context.SaveChanges();
            }
        }
    }
}
