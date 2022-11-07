using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IStatusInspecaoService : IDisposable
    {
        Task<List<StatusInspecao>> GetAll();
        Task<StatusInspecao> GetById(int id);
        Task Insert(StatusInspecao model);
        Task Update(StatusInspecao model);
        Task Delete(int id);
        Task<IPagedList<StatusInspecao>> GetPagedList(FilteredPagedListParameters parameters);
    }
}