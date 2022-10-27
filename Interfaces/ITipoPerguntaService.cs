using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface ITipoPerguntaService : IDisposable
    {
        Task<List<TipoPergunta>> GetAll();
        Task<TipoPergunta> GetById(int id);
        Task Insert(TipoPergunta model);
        Task Update(TipoPergunta model);
        Task Delete(int id);
        Task<IPagedList<TipoPergunta>> GetPagedList(FilteredPagedListParameters parameters);
    }
}