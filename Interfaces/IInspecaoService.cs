using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IInspecaoService : IDisposable
    {
        Task<List<Inspecao>> GetAll();
        Task<Inspecao> GetById(int id);
        Task Insert(Inspecao model);
        Task Update(Inspecao model);
        Task Delete(int id);
        
        Task<IPagedList<Inspecao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}