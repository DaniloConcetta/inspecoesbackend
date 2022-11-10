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
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class GruposPerguntasController : MainController
    {
        private readonly IGrupoPerguntaService _grupoPerguntaService;
        private readonly IMapper _mapper;

        public GruposPerguntasController(
                                        IGrupoPerguntaService grupoPerguntaService,
                                        IMapper mapper,
                                        INotifier notificador,
                                        IUser user) : base(notificador, user)
        {
            _grupoPerguntaService = grupoPerguntaService;
            _mapper = mapper;
        }
      
        [HttpGet] //   [AllowAnonymous]
        public async Task<ActionResult<IPagedList<GrupoPergunta>>> GetPagedList([FromQuery] FilteredPagedListParameters parameters)
        {
            var pagedList = await _grupoPerguntaService.GetPagedList(parameters);
            return CustomResponse(_mapper.Map<IPagedList<GrupoPergunta>>(pagedList));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GrupoPergunta>> GetDetailsById(int id)  
        {
            var grupoPergunta = await _grupoPerguntaService.GetDetailsById(id);

            if (grupoPergunta == null)
            {
                return NotFound();
            }
            return grupoPergunta;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutGrupoPergunta(int id, GrupoPergunta grupoPergunta)
        {
            if (id != grupoPergunta.Id)
            {
                return BadRequest();
            }

            try
            {
                await _grupoPerguntaService.Update(grupoPergunta);
            }
            catch (DbUpdateConcurrencyException)
            {
              throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<GrupoPergunta>> PostGrupoPergunta(GrupoPergunta grupoPergunta)
        {
            await _grupoPerguntaService.Insert(grupoPergunta);

            return grupoPergunta;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGrupoPergunta(int id)
        {
            var grupoPergunta = await _grupoPerguntaService.GetById(id);
            if (grupoPergunta == null)
            {
                return NotFound();
            }

            await _grupoPerguntaService.Delete(id);
                        return NoContent();
        }
    }
}
