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
    public class EvaluacionesController : ControllerBase
    {
        private readonly CursosContext _context;

        public EvaluacionesController(CursosContext context)
        {
            _context = context;
        }

        // GET: api/Evaluaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluacione>>> GetEvaluaciones()
        {
            return await _context.Evaluaciones
                .Include(e => e.Inscripcion)
                    .ThenInclude(i => i.Estudiante)
                .Include(e => e.Inscripcion)
                    .ThenInclude(i => i.Curso)
                .ToListAsync();
        }


        // GET: api/Evaluaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluacione>> GetEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return evaluacion;
        }

        // PUT: api/Evaluaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacion(int id, Evaluacione evaluacion)
        {
            if (id != evaluacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(id))
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

        // POST: api/Evaluaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evaluacione>> PostEvaluacion(Evaluacione evaluacion)
        {
            _context.Evaluaciones.Add(evaluacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluacion", new { id = evaluacion.Id }, evaluacion);
        }

        // DELETE: api/Evaluaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            _context.Evaluaciones.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluaciones.Any(e => e.Id == id);
        }
    }
}
