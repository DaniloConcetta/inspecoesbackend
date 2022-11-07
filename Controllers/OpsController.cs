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
    public class OpsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Op>>> GetOp()
        {
            return await _context.Op.ToListAsync();
        }

        // GET: api/Ops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Op>> GetOp(int id)
        {
            var op = await _context.Op.FindAsync(id);

            if (op == null)
            {
                return NotFound();
            }

            return op;
        }

        // PUT: api/Ops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOp(int id, Op op)
        {
            if (id != op.Id)
            {
                return BadRequest();
            }

            _context.Entry(op).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpExists(id))
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

        // POST: api/Ops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Op>> PostOp(Op op)
        {
            _context.Op.Add(op);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOp", new { id = op.Id }, op);
        }

        // DELETE: api/Ops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOp(int id)
        {
            var op = await _context.Op.FindAsync(id);
            if (op == null)
            {
                return NotFound();
            }

            _context.Op.Remove(op);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpExists(int id)
        {
            return _context.Op.Any(e => e.Id == id);
        }
    }
}
