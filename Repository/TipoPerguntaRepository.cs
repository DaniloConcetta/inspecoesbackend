using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class TipoPerguntaRepository : AbstractRepository<TipoPergunta>, ITipoPerguntaRepository
    {
        public TipoPerguntaRepository(ApplicationDbContext context) : base(context) { }
    }
}