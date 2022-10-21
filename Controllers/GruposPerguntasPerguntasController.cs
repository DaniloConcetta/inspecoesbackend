using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspecoes.Data;
using Inspecoes.Models;

namespace Inspecoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposPerguntasPerguntasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GruposPerguntasPerguntasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GruposPerguntasPerguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoPerguntaPergunta>>> GetGrupoPerguntaPergunta()
        {
            return await _context.GrupoPerguntaPergunta.ToListAsync();
        }

        // GET: api/GruposPerguntasPerguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoPerguntaPergunta>> GetGrupoPerguntaPergunta(int id)
        {
            var grupoPerguntaPergunta = await _context.GrupoPerguntaPergunta.FindAsync(id);

            if (grupoPerguntaPergunta == null)
            {
                return NotFound();
            }

            return grupoPerguntaPergunta;
        }

        // PUT: api/GruposPerguntasPerguntas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoPerguntaPergunta(int id, GrupoPerguntaPergunta grupoPerguntaPergunta)
        {
            if (id != grupoPerguntaPergunta.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoPerguntaPergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoPerguntaPerguntaExists(id))
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

        // POST: api/GruposPerguntasPerguntas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoPerguntaPergunta>> PostGrupoPerguntaPergunta(GrupoPerguntaPergunta grupoPerguntaPergunta)
        {
            _context.GrupoPerguntaPergunta.Add(grupoPerguntaPergunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoPerguntaPergunta", new { id = grupoPerguntaPergunta.Id }, grupoPerguntaPergunta);
        }

        // DELETE: api/GruposPerguntasPerguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoPerguntaPergunta(int id)
        {
            var grupoPerguntaPergunta = await _context.GrupoPerguntaPergunta.FindAsync(id);
            if (grupoPerguntaPergunta == null)
            {
                return NotFound();
            }

            _context.GrupoPerguntaPergunta.Remove(grupoPerguntaPergunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoPerguntaPerguntaExists(int id)
        {
            return _context.GrupoPerguntaPergunta.Any(e => e.Id == id);
        }
    }
}
