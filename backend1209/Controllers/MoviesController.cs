using backend1209.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend1209.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemdbContext _context;

        public MoviesController(CinemdbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<Movie>> Get()
        {
            var movies = await _context.Movies.ToListAsync();

            if (movies != null)
            {
                return Ok(movies);

            }
            Exception e = new();
            return BadRequest(new { message = e.Message });
        }

        [HttpPost("feladat13")]

        public async Task<ActionResult> AddNewMovie(string id, Movie movie)
        {
            var builder = WebApplication.CreateBuilder();
            string uid = builder.Configuration.GetValue<string>("Code");

            if (uid == id && uid != null)
            {
                var mov = new Movie
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    ActorId = movie.ActorId,
                    FilmTypeId = movie.FilmTypeId
                };

                if (mov != null)
                {
                    await _context.Movies.AddAsync(mov);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, "Film hozzaadasa sikerult");
                }
                return BadRequest();
            }

            return StatusCode(401, "Nincs jogosultsag  uj film felvetelehez");
        }
    }
}
