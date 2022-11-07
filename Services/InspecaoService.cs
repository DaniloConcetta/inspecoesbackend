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
    public class InspecaoService : AbstractBaseService<Inspecao>, IInspecaoService

    {
        private readonly IInspecaoRepository _repository;
        
        public InspecaoService(IInspecaoRepository repository,
                               INotifier notificador) : base(notificador, repository)
        {
            _repository = repository;
        }

        public Task<List<Inspecao>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Inspecao> GetById(int id)
        {
            return _repository.GetById(id); 
        }

        public async Task Insert(Inspecao model)
        {

            //if (!RunValidation(new CriterioValidation(), criterio)) return; //
         //   if (_criterioRepository.Search(f => f.Observacao == criterio.Observacao).Result.Any())
         //   {
          //      Notify("Já existe um Armazém com o código informado.");
         //       return;
         //   }
          // criterio.Id = Guid.NewGuid();

            await _repository.Insert(model);
        }

        public async Task Update(Inspecao model)
        {
       //     if (_criterioRepository.Search(f => f.Observacao == criterio.Observacao && f.Id != criterio.Id).Result.Any())
        //    {
       //         Notify("Já existe um Armazém com o código informado.");
        //        return;
        //    }

            await _repository.Update(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }


        public Task<IPagedList<Inspecao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _repository.GetPagedList(f =>
            (  parameters.Search == null //|| f.Descricao.Contains(parameters.Search) || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _repository?.Dispose();
        }

     
    }
}