using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/projectconstructions")]
    public class ProjectConstructionsControllers : ControllerBase
    {
        private readonly DataContext _context;

        //Constructor
        public ProjectConstructionsControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ProjectConstructions.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(ProjectConstruction projectconstruction)
        {
            _context.Add(projectconstruction);
            await _context.SaveChangesAsync();
            return Ok(projectconstruction);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var projectconstruction = await _context.ProjectConstructions.FirstOrDefaultAsync
                (x => x.Id == id);

            if (projectconstruction == null)
            {
                return NotFound();
            }
            return Ok(projectconstruction);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(ProjectConstruction projectconstruction)
        {
            _context.Update(projectconstruction);
            await _context.SaveChangesAsync();
            return Ok(projectconstruction);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.ProjectConstructions.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

