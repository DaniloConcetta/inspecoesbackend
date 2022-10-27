using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IPerguntaService : IDisposable
    {
        Task<List<Pergunta>> GetAll();
        Task<Pergunta> GetById(int id);
        Task Insert(Pergunta model);
        Task Update(Pergunta model);
        Task Delete(int id);
        
        Task<IPagedList<Pergunta>> GetPagedList(FilteredPagedListParameters parameters);
    }
}