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


    }
}