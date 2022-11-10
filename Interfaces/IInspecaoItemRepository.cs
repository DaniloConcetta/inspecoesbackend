using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IInspecaoItemRepository : IAbstractRepository<InspecaoItem>
    {
        /* exemplo
         Task<Pergunta> ObterPerguntasGrupoPergunta(int id);
        */
        Task<List<InspecaoItem>> GetByIdInspecao(int idInspecao);
    }
}