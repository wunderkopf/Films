using System.Collections.Generic;
using Newtonsoft.Json;

namespace Films.Services.Models
{
    public class FilmModel : IBaseModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "genres")]
        public ICollection<int> Genres { get; set; }
    }
}
