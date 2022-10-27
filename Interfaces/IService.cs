using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IService<TEntity> : IDisposable where TEntity : AbstractEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        //Task Adicionar(TEntity entity);
        //Task Atualizar(TEntity entity);
        //Task Remover(Guid id);
        //Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        //Task<int> SaveChanges();
    }
}