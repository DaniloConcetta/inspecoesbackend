using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Interfaces;
using Inspecoes.Models;
//using Inspecoes.Validations;

namespace Inspecoes.Services
{
    public class StatusInspecaoService : AbstractBaseService<StatusInspecao>, IStatusInspecaoService

    {
        private readonly IStatusInspecaoRepository _repository;
        public StatusInspecaoService(IStatusInspecaoRepository repository,
                                  INotifier notificador) : base(notificador, repository)
        {
            _repository = repository;

        }

        public Task<List<StatusInspecao>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<StatusInspecao> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task Insert(StatusInspecao model)
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

        public async Task Update(StatusInspecao model)
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

        public Task<IPagedList<StatusInspecao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _repository.GetPagedList(f =>
            (parameters.Search == null || f.Descricao.Contains(parameters.Search) || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _repository?.Dispose();
        }
    }
}