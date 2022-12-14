using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using Inspecoes.Data;
using Inspecoes.Models;
using Inspecoes.Interfaces;
using Inspecoes.DTOs;

namespace Inspecoes.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class StatusInspecoesController : MainController
    {
        private readonly IStatusInspecaoService _service;
        private readonly IMapper _mapper;

        public StatusInspecoesController(IStatusInspecaoService service,
                                        IMapper mapper,
                                        INotifier notificador,
                                        IUser user) : base(notificador, user)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<StatusInspecao>>> GetAllMe()
        {
            return await _service.GetAll();
        }

        [HttpGet()]
        public async Task<ActionResult<IPagedList<StatusInspecao>>> GetPagedList([FromQuery] FilteredPagedListParameters parameters)
        {
            var pagedList = await _service.GetPagedList(parameters);
            return CustomResponse(_mapper.Map<IPagedList<StatusInspecao>>(pagedList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StatusInspecao>> GetByIdMe(int id)
        {
            //var criterio = await _criterioService.GetById(id); //await _context.Criterios.FindAsync(id);
            var model = await _service.GetById(id);

            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<StatusInspecao>> PostMe(StatusInspecao model)
        {
            await _service.Insert(model);
            return model;
        }

        [HttpPut("{id:int}")] // PUT: api/Criterios/5
        public async Task<IActionResult> PutMe(int id, StatusInspecao model)
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
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMe(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}
