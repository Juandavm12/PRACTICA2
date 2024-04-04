using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/Duties")]
    public class DutiesControllers : ControllerBase
    {
        private readonly DataContext _context;

        //Constructor
        public DutiesControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Duties.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(Dutie dutie)
        {
            _context.Add(dutie);
            await _context.SaveChangesAsync();
            return Ok(dutie);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var dutie = await _context.Duties.FirstOrDefaultAsync
                (x => x.Id == id);

            if (dutie == null)
            {
                return NotFound();
            }
            return Ok(dutie);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Dutie dutie)
        {
            _context.Update(dutie);
            await _context.SaveChangesAsync();
            return Ok(dutie);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.Duties.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
