using System;
using System.Collections.Generic;
using System.Linq;
using Films.Services;
using Films.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Films.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService filmService;

        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        // GET api/films
        [HttpGet]
        public IActionResult Get()
        {
            var films = filmService.GetFilms();

            if (films == null)
                return NotFound();

            if (!films.Any())
                return NoContent();

            return new JsonResult(films, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return NotFound();

            var film = filmService.GetFilm(id);
            if (film == null)
                return NotFound();

            return new JsonResult(film, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        // POST api/films
        [HttpPost]
        public IActionResult Post([FromBody] ICollection<FilmModel> films)
        {
            if (!films.Any())
                return NotFound();

            filmService.InsertFilms(films);

            return Created(new Uri("api/films", UriKind.Relative), films.Count());
        }

        // PUT api/films/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FilmModel film)
        {
            if (id <= 0)
                return NotFound();

            if (film == null)
                return NotFound();

            film.Id = id;

            filmService.UpdateFilm(film);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            filmService.DeleteFilm(id);

            return Ok();
        }
    }
}
