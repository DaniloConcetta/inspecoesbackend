using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoPerguntaService : IDisposable
    {
        Task<List<GrupoPergunta>> GetAll();
        Task<GrupoPergunta> GetById(int id);
        Task Insert(GrupoPergunta model);
        Task Update(GrupoPergunta model);
        Task Delete(int id);

        Task<IPagedList<GrupoPergunta>> GetPagedList(FilteredPagedListParameters parameters);
        Task<GrupoPergunta> GetDetailsById(int id);

    }
}