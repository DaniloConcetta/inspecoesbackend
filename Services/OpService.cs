using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Inspecoes.Validations;
using Inspecoes.DTOs;
using Inspecoes.Interfaces;
using Inspecoes.Models;


namespace Inspecoes.Services
{
    public class OpService : AbstractBaseService<Op>, IOpService
    {
        private readonly IOpRepository _repository;
        
        public OpService(IOpRepository repository,
                               INotifier notificador) : base(notificador, repository)
        {
            _repository = repository;
        }

        public Task<List<Op>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Op> GetById(int id)
        {
            return _repository.GetById(id); 
        }

        public async Task Insert(Op model)
        {
            await _repository.Insert(model);
        }

        public async Task Update(Op model)
        {
            await _repository.Update(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public Task<IPagedList<Op>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _repository.GetPagedList(f =>
            (  parameters.Search == null || f.Opnumero.Contains(parameters.Search) //|| f.Codigo.Contains(parameters.Search) 
            ), parameters);
        }

        public override void Dispose()
        {
            _repository?.Dispose();
        }

     
    }
}