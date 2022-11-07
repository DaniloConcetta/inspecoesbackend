
using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class OpRepository : AbstractRepository<Op>, IOpRepository
    {
        public OpRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Op> GetByCodigo(string Opnumero)
        {

            return await DbSet.FirstOrDefaultAsync(p => p.Opnumero == Opnumero);

        }

    }
}
