using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspecoes.Data;
using Inspecoes.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Inspecoes.Interfaces;
using Inspecoes.DTOs;

namespace Inspecoes.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]  //[Route("api/[controller]")] 
    [ApiController]
    public class OpsController : MainController
    {
        private readonly IOpService _service;
        private readonly IMapper _mapper;

        public OpsController(IOpService service,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet()] // [AllowAnonymous]
        public async Task<ActionResult<IPagedList<Op>>> GetPagedList([FromQuery] FilteredPagedListParameters parameters)
        {
            var pagedList = await _service.GetPagedList(parameters);
            return CustomResponse(_mapper.Map<IPagedList<Op>>(pagedList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Op>> GetByIdMe(int id)
        {
            var response = await _service.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Op>> PostMe(Op model)
        {
            await _service.Insert(model);
            return model;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Op>> PutMe(int id, Op model)
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
            return model; // NoContent();//melhorar pois o retorno ideal é o retorno completo do model
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMe(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
        /*
        private bool OpExists(int id)
        {
            return _context.Op.Any(e => e.Id == id);
        }*/
    }
}
