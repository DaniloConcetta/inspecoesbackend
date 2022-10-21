using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoPerguntaRepository : IAbstractRepository<GrupoPergunta>
    {
        Task<GrupoPergunta> ObterPerguntasGrupoPergunta(int idGrupoPergunta);

        Task<GrupoPergunta> GetDetailsById(int id);

        //Task<GrupoPergunta> GetDetailsByIdGrupoProduto(int id);
    }
}