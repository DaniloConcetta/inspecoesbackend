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
    public class GruposProdutosController : MainController
    {
        private readonly IGrupoProdutoService _service;
        private readonly IMapper _mapper;

        public GruposProdutosController(IGrupoProdutoService service,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet()] 
        public async Task<ActionResult<IPagedList<GrupoProduto>>> GetPagedList([FromQuery] FilteredPagedListParameters parameters)
        {
            var pagedList = await _service.GetPagedList(parameters);
            return CustomResponse(_mapper.Map<IPagedList<GrupoProduto>>(pagedList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GrupoProduto>> GetByIdMe(int id)
        {
            var response = await _service.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<GrupoProduto>> PostMe(GrupoProduto model)
        {
            await _service.Insert(model);
            return model;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<GrupoProduto>> PutMe(int id, GrupoProduto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(model);
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
            await _service.Delete(id);
            return NoContent();
        }

    }
}
