using backend1209.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace backend1209.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly CinemdbContext _context;


        [HttpGet("feladat9")]

        public async Task<ActionResult<Actor>> Get(string name){
            var actor = await _context.Actors.Include(act => act.Movies).FirstOrDefaultAsync(act => act.ActorName == name);

            if (actor != null)
            {
                return Ok(actor);
            }
            return NotFound();
        }

        [HttpGet("feladat12")]

        public async Task<ActionResult<string>> NumOfActors() {
            var num = await _context.Actors.CountAsync();

            if (num != null)
            {
                return Ok($"Syineszek szama: {num}");
            }
            return BadRequest("nem lehet csatlakozni az adatbazishoz");
        }

        [HttpDelete("feladat16")]

        public async Task<ActionResult> Delete(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(act => act.ActorId == id);
            if (actor!=null)
            {
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
                return Ok("Sikeres torles");
            }
            return NotFound("nincs ilyen felhasynalo");
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<Actor>> GetById()
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(act => act.ActorId == id);
            return Ok(actor);
        }

        [HttpPut]
        public async Task<ActionResult<Actor>> Put(){
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ActorDto>> Post(CreateActorDto createActorDto)
        {
            var actor = new Actor() { 
                ActorName = createActorDto.ActorName
            };
            if (actor != null)
            {
                await _context.SaveChangesAsync();
                await _context.Actors.AddAsync(actor);
                
                return CreatedAtAction(actionName: nameof(GetById), routeValues: new {id = actor.ActorId }, value :new {actor.ActorId}, actor.ActorName);
            }

            return BadRequest();
        }
    }
}
