using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoProdutoRepository : IAbstractRepository<GrupoProduto>
    {
         Task<GrupoProduto> ObterGruposProdutosGrupoPergunta(int id);
    }
}