using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Films.Database
{
    [Table("Films")]
    public class Film : IBaseEntity
    {
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Column("Title", Order = 1)]
        [Required]
        public string Title { get; set; }

        //-----------------------------
        //Relationships
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        [NotMapped]
        public ICollection<Genre> Genres
        {
            get
            {
                return FilmGenre.Select(fg => fg.Genre).ToList();
            }
        }
    }
}
