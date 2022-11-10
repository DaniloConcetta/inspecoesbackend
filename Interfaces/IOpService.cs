using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IOpService : IDisposable
    {
        Task<List<Op>> GetAll();
        Task<Op> GetById(int id);
        Task Insert(Op model);
        Task Update(Op model);
        Task Delete(int id);
        
        Task<IPagedList<Op>> GetPagedList(FilteredPagedListParameters parameters);
    }
}