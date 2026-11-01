using Microsoft.AspNetCore.Mvc;
using SollicitatieTracker.Models;
using SollicitatieTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace SollicitatieTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SollicitatiesController : ControllerBase
    {
        private readonly SollicitatieTrackerContext _context;

        public SollicitatiesController(SollicitatieTrackerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alles = await _context.Sollicitaties.ToListAsync();
            return Ok(alles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getbyId = await _context.Sollicitaties.FirstOrDefaultAsync(x => x.Id == id);

            if (getbyId == null)
            {
                return NotFound();
            }
            return Ok(getbyId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSollicitatie(Sollicitatie nieuweSollicitatie)
        {
            _context.Sollicitaties.Add(nieuweSollicitatie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nieuweSollicitatie.Id }, nieuweSollicitatie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeSollicitatie(int id, Sollicitatie nieuweGegevens)
        {
            var getbyId = await _context.Sollicitaties.FirstOrDefaultAsync(x => x.Id == id);

            if (getbyId == null)
            {
                return NotFound();
            }

            getbyId.Bedrijfsnaam = nieuweGegevens.Bedrijfsnaam;
            getbyId.Functietitel = nieuweGegevens.Functietitel;
            getbyId.Status = nieuweGegevens.Status;
            getbyId.Datum = nieuweGegevens.Datum;
            getbyId.Notities = nieuweGegevens.Notities;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSollicitatie(int id)
        {
            var getbyId = await _context.Sollicitaties.FirstOrDefaultAsync(x => x.Id == id);

            if (getbyId == null)
            {
                return NotFound();
            }

            _context.Sollicitaties.Remove(getbyId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
