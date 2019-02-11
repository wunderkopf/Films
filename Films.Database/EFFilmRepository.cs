using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var film = context.Films
            .Include(f => f.FilmGenre)
            .FirstOrDefault(f => f.Id == id);

            return film;
        }

        public IEnumerable<Film> Get()
        {
            var films = context.Films
            .Include(fg => fg.FilmGenre)
            .ThenInclude(fg => fg.Genre);

            return films.ToList();
        }

        public async Task<IEnumerable<Film>> GetAsync()
        {
            var films = context.Films.Include(fg => fg.FilmGenre).ThenInclude(fg => fg.Genre);
            return await films.ToListAsync();
        }

        public void Insert(ICollection<Film> films)
        {
            if (films == null)
                throw new ArgumentNullException(nameof(films));

            context.Films.AddRange(films);
            context.SaveChanges();
        }

        public void Update(Film newFilm)
        {
            var film = FindById(newFilm.Id);
            if (film != null)
            {
                context.FilmsGenres.RemoveRange(film.FilmGenre);
                film.Title = newFilm.Title;
                film.FilmGenre = newFilm.FilmGenre;
                context.Films.Update(film);
                context.SaveChanges();
            }
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
