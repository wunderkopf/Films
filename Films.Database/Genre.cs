using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Database
{
    [Table("Genres")]
    public class Genre : IBaseEntity
    {
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Column("Title", Order = 1)]
        [Required]
        public string Title { get; set; }

        //-----------------------------
        //Relationships
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }
    }
}
