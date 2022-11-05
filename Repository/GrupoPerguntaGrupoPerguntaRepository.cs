using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class GrupoPerguntaGrupoProdutoRepository : AbstractRepository<GrupoPerguntaGrupoProduto>, IGrupoPerguntaGrupoProdutoRepository
    {
        public GrupoPerguntaGrupoProdutoRepository(ApplicationDbContext context) : base(context) { }
    }
}