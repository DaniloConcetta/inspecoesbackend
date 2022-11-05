using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class GrupoPerguntaPerguntaRepository : AbstractRepository<GrupoPerguntaPergunta>, IGrupoPerguntaPerguntaRepository
    {
        public GrupoPerguntaPerguntaRepository(ApplicationDbContext context) : base(context) { }
    }
}