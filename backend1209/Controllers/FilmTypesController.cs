using backend1209.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend1209.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTypesController : ControllerBase
    {
        private readonly CinemdbContext _context;

        public FilmTypesController(CinemdbContext context)
        { 
            _context = context;
        }

        [HttpGet("feladat11")]
        
        public async Task<ActionResult<FilmType>> Get()
        {
            var filmtypes = await _context.FilmTypes.Include(flm => flm.Moives).ToListAsync();

            if (filmtypes != null)
            {
                return Ok(filmtypes);
            }

            Exception e = new();
            return BadRequest(new { message = e.Message });
        }
    }
}
