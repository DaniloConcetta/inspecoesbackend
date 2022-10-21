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
    public class GruposProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GruposProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GrupoProduto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoProduto>>> GetGruposProdutos()
        {
            return await _context.GruposProdutos.ToListAsync();
        }

        // GET: api/GrupoProduto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoProduto>> GetGrupoProduto(int id)
        {
            var grupoProduto = await _context.GruposProdutos.FindAsync(id);

            if (grupoProduto == null)
            {
                return NotFound();
            }

            return grupoProduto;
        }

        // PUT: api/GrupoProduto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoProduto(int id, GrupoProduto grupoProduto)
        {
            if (id != grupoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoProdutoExists(id))
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

        // POST: api/GrupoProduto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoProduto>> PostGrupoProduto(GrupoProduto grupoProduto)
        {
            _context.GruposProdutos.Add(grupoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoProduto", new { id = grupoProduto.Id }, grupoProduto);
        }

        // DELETE: api/GrupoProduto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoProduto(int id)
        {
            var grupoProduto = await _context.GruposProdutos.FindAsync(id);
            if (grupoProduto == null)
            {
                return NotFound();
            }

            _context.GruposProdutos.Remove(grupoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoProdutoExists(int id)
        {
            return _context.GruposProdutos.Any(e => e.Id == id);
        }
    }
}
