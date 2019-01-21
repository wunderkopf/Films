using System.Linq;

namespace Films.Database
{
    public static class ApplicationContextExtensions
    {
        public static void EnsureSeedData(this ApplicationContext context)
        {
            if (context.Films.Any())
                return;

            Genre drama = new Genre
            {
                Title = "drama"
            };

            Genre action = new Genre
            {
                Title = "action"
            };

            Genre comedy = new Genre
            {
                Title = "comedy"
            };

            Genre fantasy = new Genre
            {
                Title = "fantasy"
            };

            Genre sf = new Genre
            {
                Title = "sci-fi"
            };

            Genre thriller = new Genre
            {
                Title = "thriller"
            };

            Genre horror = new Genre
            {
                Title = "horror"
            };

            Film f1 = new Film
            {
                Title = "Fight Club"
            };

            Film f2 = new Film
            {
                Title = "The Dark Knight"
            };

            Film f3 = new Film
            {
                Title = "Star Wars: Episode V - The Empire Strikes Back"
            };

            Film f4 = new Film
            {
                Title = "Alien"
            };

            Film f5 = new Film
            {
                Title = "Trainspotting"
            };

            context.AddRange(
                new FilmGenre { Film = f1, Genre = drama },
                new FilmGenre { Film = f1, Genre = action },
                new FilmGenre { Film = f1, Genre = thriller }
            );

            context.AddRange(
                new FilmGenre { Film = f2, Genre = drama },
                new FilmGenre { Film = f2, Genre = action },
                new FilmGenre { Film = f2, Genre = fantasy }
            );

            context.AddRange(
                new FilmGenre { Film = f3, Genre = drama },
                new FilmGenre { Film = f3, Genre = action },
                new FilmGenre { Film = f3, Genre = fantasy },
                new FilmGenre { Film = f3, Genre = sf }
            );

            context.AddRange(
                new FilmGenre { Film = f4, Genre = drama },
                new FilmGenre { Film = f4, Genre = action },
                new FilmGenre { Film = f4, Genre = horror },
                new FilmGenre { Film = f4, Genre = sf },
                new FilmGenre { Film = f4, Genre = thriller }
            );

            context.AddRange(
                new FilmGenre { Film = f5, Genre = drama },
                new FilmGenre { Film = f5, Genre = action },
                new FilmGenre { Film = f5, Genre = comedy }
            );

            context.SaveChanges();
        }
    }
}
