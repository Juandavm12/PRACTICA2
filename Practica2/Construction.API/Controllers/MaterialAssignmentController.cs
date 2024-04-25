using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/MaterialAssignments")]
    public class MaterialAssignmentControllers : ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public MaterialAssignmentControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.MaterialAssignments.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(MaterialAssignment materialassignment)
        {
            _context.Add(materialassignment);
            await _context.SaveChangesAsync();
            return Ok(materialassignment);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var materialassignment = await _context.MaterialAssignments.FirstOrDefaultAsync
                (x => x.Id == id);

            if (materialassignment == null)
            {
                return NotFound();
            }
            return Ok(materialassignment);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(MaterialAssignment materialassignment)
        {
            _context.Update(materialassignment);
            await _context.SaveChangesAsync();
            return Ok(materialassignment);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.MaterialAssignments.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
