using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IInspecaoRepository : IAbstractRepository<Inspecao>
    {
        /* exemplo
         Task<Pergunta> ObterPerguntasGrupoPergunta(int id);
        */
    }
}