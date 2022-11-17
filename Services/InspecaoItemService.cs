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
    public class InspecaoItemService : AbstractBaseService<InspecaoItem>, IInspecaoItemService
    {
        private readonly IInspecaoItemRepository _repository;
        
        public InspecaoItemService(IInspecaoItemRepository repository,
                               INotifier notificador) : base(notificador, repository)
        {
            _repository = repository;
        }

        public Task<List<InspecaoItem>> GetAll()
        {
            return _repository.GetAll();
        }

        /*public Task<List<InspecaoItem>> GetAllInspecao()
        {
            return _repository.GetAllInspecao();
        }*/

        public Task<InspecaoItem> GetById(int id)
        {
            return _repository.GetById(id); 
        }

        public async Task Insert(InspecaoItem model)
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

        public async Task Update(InspecaoItem model)
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


        public Task<IPagedList<InspecaoItem>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _repository.GetPagedList(f =>
            (  parameters.Search == null || f.Descritivo.Contains(parameters.Search) //|| f.Codigo.Contains(parameters.Search) 
            ), parameters);
        }

        public override void Dispose()
        {
            _repository?.Dispose();
        }

     
    }
}