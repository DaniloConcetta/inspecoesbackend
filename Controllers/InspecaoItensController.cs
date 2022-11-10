using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspecoes.Data;
using Inspecoes.Models;
using Inspecoes.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Inspecoes.DTOs;

namespace Inspecoes.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]  //[Route("api/[controller]")] 
    public class InspecaoItensController : MainController
    {
        private readonly IInspecaoItemService _service;
        private readonly IMapper _mapper;

        public InspecaoItensController(IInspecaoItemService service,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _service = service;
            _mapper = mapper;
            //user.GetUserEmail
        }

       
        [HttpGet()]
        public async Task<ActionResult<IPagedList<InspecaoItem>>> GetPagedList([FromQuery] FilteredPagedListParameters parameters)
        {
            var pagedList = await _service.GetPagedList(parameters);
            return CustomResponse(_mapper.Map<IPagedList<InspecaoItem>>(pagedList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InspecaoItem>> GetByIdMe(int id)
        {
            var response = await _service.GetById(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }


        [HttpPost]
        public async Task<ActionResult<InspecaoItem>> PostMe(InspecaoItem model)
        {
            await _service.Insert(model);
            return model;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<InspecaoItem>> PutMe(int id, InspecaoItem model)
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

    }
}
