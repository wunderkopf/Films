using System.Collections.Generic;
using Newtonsoft.Json;

namespace Films.Services.Models
{
    public class GenreModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        //public ICollection<FilmModel> Films { get; set; }
    }
}
