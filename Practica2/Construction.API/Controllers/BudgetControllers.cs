using Construction.API.Data;
using Construction.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Construction.API.Controllers
{
    [ApiController]
    [Route("/api/Budgets")]
    public class BudgetControllers: ControllerBase
    {

        private readonly DataContext _context;

        //Constructor
        public BudgetControllers(DataContext context)
        {
            _context = context;
        }

        //Metodo Get - Lista (Read all)
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Budgets.ToListAsync());
        }

        //Create
        [HttpPost]
        public async Task<ActionResult> Post(Budget budget)
        {
            _context.Add(budget);
            await _context.SaveChangesAsync();
            return Ok(budget);
        }

        //Get por ID (Read)
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync
                (x => x.Id == id);

            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Budget budget)
        {
            _context.Update(budget);
            await _context.SaveChangesAsync();
            return Ok(budget);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedrows = await _context.Budgets.Where(x => x.Id == id).
                ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

