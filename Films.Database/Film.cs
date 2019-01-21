using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Database
{
    [Table("Films")]
    public class Film : IBaseEntity
    {
        [Column("Id", Order = 0)]
        public int Id { get; set; }

        [Column("Title", Order = 1)]
        public string Title { get; set; }

        //-----------------------------
        //Relationships
        public ICollection<FilmGenre> FilmGenre { get; set; }
    }
}
