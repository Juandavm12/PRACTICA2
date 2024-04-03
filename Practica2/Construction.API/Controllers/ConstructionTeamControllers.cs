using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/ConstructionTeams")]
    public class ConstructionTeamControllers : ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public ConstructionTeamControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ConstructionTeams.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(ConstructionTeam constructionteam)
        {
            _context.Add(constructionteam);
            await _context.SaveChangesAsync();
            return Ok(constructionteam);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var constructionteam = await _context.ConstructionTeams.FirstOrDefaultAsync
                (x => x.Id == id);

            if (constructionteam == null)
            {
                return NotFound();
            }
            return Ok(constructionteam);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(ConstructionTeam constructionteam)
        {
            _context.Update(constructionteam);
            await _context.SaveChangesAsync();
            return Ok(constructionteam);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.ConstructionTeams.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}