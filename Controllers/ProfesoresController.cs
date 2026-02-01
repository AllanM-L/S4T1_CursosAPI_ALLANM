using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursosAPI.Models;

namespace CursosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly CursosContext _context;

        public ProfesoresController(CursosContext context)
        {
            _context = context;
        }

        // GET: api/Profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesore>>> GetProfesores()
        {
            return await _context.Profesores.ToListAsync();
        }

        // GET: api/Profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesore>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/Profesores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesore profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesore>> PostProfesor(Profesore profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesor", new { id = profesor.Id }, profesor);
        }

        // DELETE: api/Profesores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
