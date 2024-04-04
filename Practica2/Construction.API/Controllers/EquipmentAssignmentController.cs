using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/EquipmentAssignments")]
    public class EquipmentAssignmentController : ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public EquipmentAssignmentController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EquipmentAssignments.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(EquipmentAssignment equipmentassignment)
        {
            _context.Add(equipmentassignment);
            await _context.SaveChangesAsync();
            return Ok(equipmentassignment);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var equipmentassignment = await _context.EquipmentAssignments.FirstOrDefaultAsync
                (x => x.Id == id);

            if (equipmentassignment == null)
            {
                return NotFound();
            }
            return Ok(equipmentassignment);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(EquipmentAssignment equipmentassignment)
        {
            _context.Update(equipmentassignment);
            await _context.SaveChangesAsync();
            return Ok(equipmentassignment);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.EquipmentAssignments.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
