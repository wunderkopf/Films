using System.Linq;
using Films.Services;
using Films.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Films.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IService<GenreModel> genreService;

        public GenresController(IService<GenreModel> genreService)
        {
            this.genreService = genreService;
        }

        // GET api/genres
        [HttpGet]
        public IActionResult Get()
        {
            var genres = genreService.Get();

            if (genres == null)
                return NotFound();

            if (!genres.Any())
                return NoContent();

            return new JsonResult(genres, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
