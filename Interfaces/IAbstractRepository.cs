using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Inspecoes.Models;
//using Inspecoes.DTOs;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inspecoes.Interfaces
{
    public interface IAbstractRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity);
        void InsertNoAsync(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(int id, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAll();
        //Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order);
        Task Update(TEntity entity);
        void UpdateNoAsync(TEntity entity);
        int SaveChangesNoAsync();
        void UpdateRangeNoAsync(IEnumerable<TEntity> entity);
        Task UpdateRange(IEnumerable<TEntity> entity);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetPredicate(Expression<Func<TEntity, bool>> predicate, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetPredicateList(Expression<Func<TEntity, bool>> predicate, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes);
        //public Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters);
      //  Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes);
        IDbContextTransaction EntityDatabaseTransaction();
        Task<int> SaveChanges();
    }
}