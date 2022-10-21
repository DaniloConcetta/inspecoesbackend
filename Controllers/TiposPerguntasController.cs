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
    public class TiposPerguntasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TiposPerguntasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TiposPerguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPergunta>>> GetTiposPerguntas()
        {
            return await _context.TiposPerguntas.ToListAsync();
        }

        // GET: api/TiposPerguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPergunta>> GetTipoPergunta(int id)
        {
            var tipoPergunta = await _context.TiposPerguntas.FindAsync(id);

            if (tipoPergunta == null)
            {
                return NotFound();
            }

            return tipoPergunta;
        }

        // PUT: api/TiposPerguntas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPergunta(int id, TipoPergunta tipoPergunta)
        {
            if (id != tipoPergunta.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPerguntaExists(id))
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

        // POST: api/TiposPerguntas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPergunta>> PostTipoPergunta(TipoPergunta tipoPergunta)
        {
            _context.TiposPerguntas.Add(tipoPergunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPergunta", new { id = tipoPergunta.Id }, tipoPergunta);
        }

        // DELETE: api/TiposPerguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPergunta(int id)
        {
            var tipoPergunta = await _context.TiposPerguntas.FindAsync(id);
            if (tipoPergunta == null)
            {
                return NotFound();
            }

            _context.TiposPerguntas.Remove(tipoPergunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPerguntaExists(int id)
        {
            return _context.TiposPerguntas.Any(e => e.Id == id);
        }
    }
}
