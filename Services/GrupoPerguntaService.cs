using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Interfaces;
using Inspecoes.Models;


namespace Inspecoes.Services
{
    public class GrupoPerguntaService : AbstractBaseService<GrupoPergunta>, IGrupoPerguntaService

    {
        private readonly IGrupoPerguntaRepository _repository;
        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IGrupoProdutoRepository _grupoprodutoRepository;

        public GrupoPerguntaService(IGrupoPerguntaRepository repository,
                             IPerguntaRepository perguntaRepository,
                             IGrupoProdutoRepository grupoProdutoRepository,
                               INotifier notificador) : base(notificador, repository)
        {
            _repository = repository;
            _perguntaRepository = perguntaRepository;
            _grupoprodutoRepository = grupoProdutoRepository;
        }

        public Task<List<GrupoPergunta>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<GrupoPergunta> GetById(int id)
        {
            return _repository.GetById(id);
        }


        public async Task Insert(GrupoPergunta model)
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

        public async Task Update(GrupoPergunta model)
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

        public Task<IPagedList<GrupoPergunta>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _repository.GetPagedList(f =>
            (parameters.Search == null || f.Codigo.Contains(parameters.Search) || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public async Task<GrupoPergunta> GetDetailsById(int id)
        {
            GrupoPergunta grupoPergunta;
            grupoPergunta = new GrupoPergunta();
            grupoPergunta = await _repository.GetDetailsById(id);

            grupoPergunta.Perguntas = new List<Pergunta>();
            foreach (var grupoPerguntaPergunta in grupoPergunta.GrupoPerguntaPerguntas)
            {
                Pergunta pergunta = new Pergunta();
                pergunta = await _perguntaRepository.GetById(grupoPerguntaPergunta.PerguntaId);
                grupoPergunta.Perguntas.Add(pergunta);
            }

            grupoPergunta.GruposProdutos = new List<GrupoProduto>();
            foreach (var grupoPerguntaGrupoProduto in grupoPergunta.GrupoPerguntaGruposProdutos)
            {
                GrupoProduto grupoProduto = new GrupoProduto();
                grupoProduto = await _grupoprodutoRepository.GetById(grupoPerguntaGrupoProduto.GrupoProdutoId);
                grupoPergunta.GruposProdutos.Add(grupoProduto);
            }

            return grupoPergunta;
        }

        public override void Dispose()
        {
            _repository?.Dispose();
        }

     
    }
}