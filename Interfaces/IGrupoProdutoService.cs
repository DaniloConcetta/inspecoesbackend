using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IGrupoProdutoService : IDisposable
    {
        Task<List<GrupoProduto>> GetAll();
        Task<GrupoProduto> GetById(int id);
        Task Insert(GrupoProduto model);
        Task Update(GrupoProduto model);
        Task Delete(int id);

        Task<IPagedList<GrupoProduto>> GetPagedList(FilteredPagedListParameters parameters);

    }
}