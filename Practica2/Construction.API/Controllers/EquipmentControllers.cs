using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/Equipments")]
    public class EquipmentControllers : ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public EquipmentControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Equipments.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(Equipment equipment)
        {
            _context.Add(equipment);
            await _context.SaveChangesAsync();
            return Ok(equipment);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync
                (x => x.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Equipment equipment)
        {
            _context.Update(equipment);
            await _context.SaveChangesAsync();
            return Ok(equipment);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.Equipments.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}