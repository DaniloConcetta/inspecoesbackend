using Inspecoes.Models;

namespace Inspecoes.Services
{
    public interface IGruposProdutoPService
    {
        //Task<GrupoProdutoProtheus> GrupoProdutoProtheus(GruposProdutoPService gruposProdutoPService)
        Task<GrupoProdutoSBM> GrupoProdutoProtheus()
        {
            throw new System.NotImplementedException();
        }
        /*
        Task<string> GrupoProdutoProtheus()
        {
            throw new System.NotImplementedException();
        }
        */
    }
}
