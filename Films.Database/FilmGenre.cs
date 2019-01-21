using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Database
{
    [Table("FilmsGenres")]
    public class FilmGenre : IBaseEntity
    {
        [Column("FilmId", Order = 0)]
        public int FilmId { get; set; }

        [Column("GenreId", Order = 1)]
        public int GenreId { get; set; }

        //-----------------------------
        //Relationships
        public virtual Film Film { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
