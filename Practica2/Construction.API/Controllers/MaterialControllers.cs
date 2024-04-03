using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/Materials")]
    public class MaterialControllers : ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public MaterialControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Materials.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(Material material)
        {
            _context.Add(material);
            await _context.SaveChangesAsync();
            return Ok(material);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var equipment = await _context.Materials.FirstOrDefaultAsync
                (x => x.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Material material)
        {
            _context.Update(material);
            await _context.SaveChangesAsync();
            return Ok(material);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.Materials.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}