
using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class GrupoProdutoRepository : AbstractRepository<GrupoProduto>, IGrupoProdutoRepository
    {
        public GrupoProdutoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<GrupoProduto> ObterGruposProdutosGrupoPergunta(int id)
        {
            return null; /*await Db.Perguntas.AsNoTracking()
                   .Include(c => c.GrupoPergunta)
                   .FirstOrDefaultAsync(c => c.GrupoPerguntaId == id);*/
        }


    }
}
