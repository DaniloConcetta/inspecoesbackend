using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IInspecaoItemService : IDisposable
    {
        Task<List<InspecaoItem>> GetAll();
        Task<InspecaoItem> GetById(int id);
        
        //testar se status da inspeção é aberta se não for não pode editar
        Task Insert(InspecaoItem model);
        Task Update(InspecaoItem model);
        Task Delete(int id);
        
        //final teste
        Task<IPagedList<InspecaoItem>> GetPagedList(FilteredPagedListParameters parameters);
    }
}