using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class GrupoPerguntaRepository : AbstractRepository<GrupoPergunta>, IGrupoPerguntaRepository
    {
        public GrupoPerguntaRepository(ApplicationDbContext context) : base(context) { }


        public async Task<GrupoPergunta> GetDetailsById(int id)
        {

            return await Db.GruposPerguntas.AsNoTracking()
                   .Include(c => c.GrupoPerguntaPerguntas)
                   .Include(c => c.GrupoPerguntaGruposProdutos)
                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        /* exemplo
        public async Task<GrupoPergunta> ObterPerguntasGrupoPergunta(int idGrupoPergunta)
        {
            return await Db.GruposPerguntas.AsNoTracking()
                   .Include(c => c.Perguntas)
                   .Include(c => c.GruposProdutos)
                   .FirstOrDefaultAsync(c => c.Id == idGrupoPergunta);
        }
        */

    }
}