using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class InspecaoItemRepository : AbstractRepository<InspecaoItem>, IInspecaoItemRepository
    {
        public InspecaoItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<InspecaoItem>> GetByIdInspecao(int idInspecao)
        {
            return await DbSet.Where(p => p.InspecaoId == idInspecao).ToListAsync();
        }


    }
}