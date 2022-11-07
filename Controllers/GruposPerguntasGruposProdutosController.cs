using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Inspecoes.Models;
using Inspecoes.Interfaces;
using Inspecoes.DTOs;

namespace Inspecoes.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class GruposPerguntasGruposProdutosController : MainController
    {
        private readonly IGrupoPerguntaGrupoProdutoRepository _repository;
        private readonly IMapper _mapper;

        public GruposPerguntasGruposProdutosController(IGrupoPerguntaGrupoProdutoRepository repository,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GrupoPerguntaGrupoProduto>>> GetAllMe()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GrupoPerguntaGrupoProduto>> GetByIdMe(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<GrupoPerguntaGrupoProduto>> PostMe(GrupoPerguntaGrupoProduto model)
        {
            await _repository.Insert(model);
            return model;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<GrupoPerguntaGrupoProduto>> PutMe(int id, GrupoPerguntaGrupoProduto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return model;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMe(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }

    }
}
