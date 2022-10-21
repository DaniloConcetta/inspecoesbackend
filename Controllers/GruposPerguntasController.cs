using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspecoes.Data;
using Inspecoes.Models;
using Inspecoes.Interfaces;

namespace Inspecoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposPerguntasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGrupoPerguntaService _grupoPerguntaService; 


        public GruposPerguntasController(ApplicationDbContext context,
                                        IGrupoPerguntaService grupoPerguntaService)
        {
            _context = context;
            _grupoPerguntaService = grupoPerguntaService;
        }

        // GET: api/GrupoPergunta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoPergunta>>> GetGruposPerguntas()
        {
            return await _context.GruposPerguntas.ToListAsync();
        }

        // GET: api/GrupoPergunta/5
        [HttpGet("antigo/{id}")]
        public async Task<ActionResult<GrupoPergunta>> GetGrupoPergunta(int id)
        {
            //var grupoPergunta = await _context.GruposPerguntas.FindAsync(id);
            var grupoPergunta = await _grupoPerguntaService.GetById(id);
            //var grupoPergunta = await _grupoPerguntaRepository.ObterPerguntasGrupoPergunta(id);

            if (grupoPergunta == null)
            {
                return NotFound();
            }
            return grupoPergunta;
        }


        // GET: api/GrupoPergunta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoPergunta>> GetDetailsById(int id)  
        {
            //var grupoPergunta = await _context.GruposPerguntas.FindAsync(id);
            var grupoPergunta = await _grupoPerguntaService.GetDetailsById(id);
            //var grupoPergunta = await _grupoPerguntaRepository.ObterPerguntasGrupoPergunta(id);

            if (grupoPergunta == null)
            {
                return NotFound();
            }
            return grupoPergunta;
        }

        // PUT: api/GrupoPergunta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoPergunta(int id, GrupoPergunta grupoPergunta)
        {
            if (id != grupoPergunta.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoPergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoPerguntaExists(id))
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

        // POST: api/GrupoPergunta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoPergunta>> PostGrupoPergunta(GrupoPergunta grupoPergunta)
        {
            _context.GruposPerguntas.Add(grupoPergunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoPergunta", new { id = grupoPergunta.Id }, grupoPergunta);
        }

        // DELETE: api/GrupoPergunta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoPergunta(int id)
        {
            var grupoPergunta = await _context.GruposPerguntas.FindAsync(id);
            if (grupoPergunta == null)
            {
                return NotFound();
            }

            _context.GruposPerguntas.Remove(grupoPergunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoPerguntaExists(int id)
        {
            return _context.GruposPerguntas.Any(e => e.Id == id);
        }
    }
}
