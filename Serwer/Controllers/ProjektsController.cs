using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serwer.Models;
using Serwer.Controllers;

namespace Serwer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektsController : ControllerBase
    {
        private readonly ProjektContext _context;

        public ProjektsController(ProjektContext context)
        {
            _context = context;
        }

        // GET: api/Projekts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projekt>>> GetProjektItems()
        {
            return await _context.ProjektItems.ToListAsync();
        }

        // GET: api/Projekts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projekt>> GetProjekt(long id)
        {
            var projekt = await _context.ProjektItems.FindAsync(id);
            await _context.ProjektDetailsItems.ToListAsync();
            await _context.PersonProjekts.ToListAsync();
            var Persons = await _context.PersonItems.ToListAsync();
            projekt.Persony = SingleProjekt.GetAllDataFromProjekt(projekt.PersonProjekty, Persons);

            if (projekt == null)
            {
                return NotFound();
            }

            return projekt;
        }

        // PUT: api/Projekts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjekt(long id, Projekt projekt)
        {
            if (id != projekt.ProjektID)
            {
                return BadRequest();
            }

            _context.Entry(projekt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjektExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projekts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projekt>> PostProjekt(Projekt projekt)
        {
            _context.ProjektItems.Add(projekt);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjekt", new { id = projekt.Id }, projekt);
            return CreatedAtAction(nameof(GetProjekt), new { id = projekt.ProjektID }, projekt);
        }

        // DELETE: api/Projekts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjekt(long id)
        {
            var projekt = await _context.ProjektItems.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }

            _context.ProjektItems.Remove(projekt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjektExists(long id)
        {
            return _context.ProjektItems.Any(e => e.ProjektID == id);
        }
    }
}
