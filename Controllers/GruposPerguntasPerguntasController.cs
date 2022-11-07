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
    public class GruposPerguntasPerguntasController : MainController
    {
        private readonly IGrupoPerguntaPerguntaRepository _repository;
        private readonly IMapper _mapper;

        public GruposPerguntasPerguntasController(IGrupoPerguntaPerguntaRepository repository,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GrupoPerguntaPergunta>>> GetAllMe()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GrupoPerguntaPergunta>> GetByIdMe(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<GrupoPerguntaPergunta>> PostMe(GrupoPerguntaPergunta model)
        {
            await _repository.Insert(model);
            return model;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<GrupoPerguntaPergunta>> PutMe(int id, GrupoPerguntaPergunta model)
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
