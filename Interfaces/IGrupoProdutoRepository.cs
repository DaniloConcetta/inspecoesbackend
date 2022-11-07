using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoProdutoRepository : IAbstractRepository<GrupoProduto>
    {
        /* exemplo
         Task<GrupoProduto> ObterGruposProdutosGrupoPergunta(int id);
        */
        Task<GrupoProduto> GetByCodigo(string codigo);
    }
    
}