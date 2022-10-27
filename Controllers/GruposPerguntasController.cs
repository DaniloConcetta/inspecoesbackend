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
        private readonly IGrupoPerguntaService _grupoPerguntaService; 

        public GruposPerguntasController(IGrupoPerguntaService grupoPerguntaService)
        {
            _grupoPerguntaService = grupoPerguntaService;
        }

        // GET: api/GrupoPergunta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoPergunta>>> GetGruposPerguntas()
        {
            return await _grupoPerguntaService.GetAll();
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

            try
            {
                await _grupoPerguntaService.Update(grupoPergunta);
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
            
            await _grupoPerguntaService.Insert(grupoPergunta);

            return CreatedAtAction("GetGrupoPergunta", new { id = grupoPergunta.Id }, grupoPergunta);
        }

        // DELETE: api/GrupoPergunta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoPergunta(int id)
        {
            var grupoPergunta = await _grupoPerguntaService.GetById(id);
            if (grupoPergunta == null)
            {
                return NotFound();
            }

            await _grupoPerguntaService.Delete(id);

            return NoContent();
        }

        private bool GrupoPerguntaExists(int id)
        {
            return _grupoPerguntaService.GetById(id).IsCanceled;
        }
    }
}
