using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoPerguntaService : IDisposable
    {
        Task Adicionar(GrupoPergunta model);
        Task Atualizar(GrupoPergunta model);
        Task Remover(int id);
        Task<List<GrupoPergunta>> GetAll();
        Task<GrupoPergunta> GetById(int id);

        Task<GrupoPergunta> GetDetailsById(int id);
        //   Task<IPagedList<GrupoPergunta>> GetPagedList(FilteredPagedListParameters parameters);
    }
}