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
    public class GruposPerguntasGruposProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GruposPerguntasGruposProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GruposPerguntasGruposProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoPerguntaGrupoProduto>>> GetGrupoPerguntaGrupoProduto()
        {
            return await _context.GrupoPerguntaGrupoProduto.ToListAsync();
        }

        // GET: api/GruposPerguntasGruposProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoPerguntaGrupoProduto>> GetGrupoPerguntaGrupoProduto(int id)
        {
            var grupoPerguntaGrupoProduto = await _context.GrupoPerguntaGrupoProduto.FindAsync(id);

            if (grupoPerguntaGrupoProduto == null)
            {
                return NotFound();
            }

            return grupoPerguntaGrupoProduto;
        }

        // PUT: api/GruposPerguntasGruposProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoPerguntaGrupoProduto(int id, GrupoPerguntaGrupoProduto grupoPerguntaGrupoProduto)
        {
            if (id != grupoPerguntaGrupoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoPerguntaGrupoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoPerguntaGrupoProdutoExists(id))
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

        // POST: api/GruposPerguntasGruposProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoPerguntaGrupoProduto>> PostGrupoPerguntaGrupoProduto(GrupoPerguntaGrupoProduto grupoPerguntaGrupoProduto)
        {
            _context.GrupoPerguntaGrupoProduto.Add(grupoPerguntaGrupoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoPerguntaGrupoProduto", new { id = grupoPerguntaGrupoProduto.Id }, grupoPerguntaGrupoProduto);
        }

        // DELETE: api/GruposPerguntasGruposProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoPerguntaGrupoProduto(int id)
        {
            var grupoPerguntaGrupoProduto = await _context.GrupoPerguntaGrupoProduto.FindAsync(id);
            if (grupoPerguntaGrupoProduto == null)
            {
                return NotFound();
            }

            _context.GrupoPerguntaGrupoProduto.Remove(grupoPerguntaGrupoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoPerguntaGrupoProdutoExists(int id)
        {
            return _context.GrupoPerguntaGrupoProduto.Any(e => e.Id == id);
        }
    }
}
