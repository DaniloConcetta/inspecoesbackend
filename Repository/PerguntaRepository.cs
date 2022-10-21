
using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class PerguntaRepository : AbstractRepository<Pergunta>, IPerguntaRepository
    {
        public PerguntaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Pergunta> ObterPerguntasGrupoPergunta(int id)
        {
            return null; /*await Db.Perguntas.AsNoTracking()
                   .Include(c => c.GrupoPergunta)
                   .FirstOrDefaultAsync(c => c.GrupoPerguntaId == id);*/
        }


    }
}
