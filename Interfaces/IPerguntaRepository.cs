using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IPerguntaRepository : IAbstractRepository<Pergunta>
    {
         Task<Pergunta> ObterPerguntasGrupoPergunta(int id);
    }
}