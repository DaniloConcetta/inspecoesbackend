using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

using Inspecoes.DTOs;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Inspecoes.Data;

namespace Inspecoes.Repository
{
    public abstract class AbstractRepository<TEntity> : IAbstractRepository<TEntity> where TEntity : AbstractEntity, new()
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected AbstractRepository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetById(int id, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsNoTracking().AsQueryable();
            foreach (var include in stringIncludes ?? new List<string>())
            {
                includedData = includedData.Include(include);
            }
            foreach (var include in includes)
            {
                includedData = includedData.Include(include);
            }
            return await includedData.FirstAsync(p => p.Id == id);
        }

        public virtual async Task<TEntity> GetPredicate(Expression<Func<TEntity, bool>> predicate, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsNoTracking().AsQueryable();
            foreach (var include in stringIncludes ?? new List<string>())
            {
                includedData = includedData.Include(include);
            }
            foreach (var include in includes)
            {
                includedData = includedData.Include(include);
            }
            return await includedData.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetPredicateList(Expression<Func<TEntity, bool>> predicate, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsNoTracking().AsQueryable();
            foreach (var include in stringIncludes ?? new List<string>())
            {
                includedData = includedData.Include(include);
            }
            foreach (var include in includes)
            {
                includedData = includedData.Include(include);
            }
            return await includedData.Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters, List<string> stringIncludes = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsQueryable();
            foreach (var include in stringIncludes ?? new List<string>())
            {
                includedData = includedData.Include(include);
            }
            foreach (var include in includes)
            {
                includedData = includedData.Include(include);
            }
            var dadosFiltrados = includedData.Where(predicate);

            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TEntity>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task UpdateModified(TEntity entity)
        {
            DbSet.Attach(entity);
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public virtual void InsertNoAsync(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChangesNoAsync();
        }

        public virtual void UpdateNoAsync(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChangesNoAsync();
        }

        public virtual int SaveChangesNoAsync()
        {
            return Db.SaveChanges();
        }

        public virtual void UpdateRangeNoAsync(IEnumerable<TEntity> entity)
        {
            DbSet.UpdateRange(entity);
            SaveChangesNoAsync();
        }

        public virtual async Task UpdateRange(IEnumerable<TEntity> entity)
        {
            DbSet.UpdateRange(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public virtual async Task DeleteAll(List<int> listId)
        {
            foreach (var id in listId)
            {
                DbSet.Remove(new TEntity { Id = id });
            }
            await SaveChanges();
        }

        public IDbContextTransaction EntityDatabaseTransaction()
        {
            return Db.Database.BeginTransaction();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}