using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspecoes.Data;
using Inspecoes.Models;
using Inspecoes.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Inspecoes.Interfaces;

namespace Inspecoes.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]  //[Route("api/[controller]")] 
    public class InspecaoLaudosController : MainController
    {
        private readonly IInspecaoLaudoService _service;
        private readonly IMapper _mapper;
        public InspecaoLaudosController(IInspecaoLaudoService service,
                                   IMapper mapper,
                                   INotifier notificador,
                                   IUser user) : base(notificador, user)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{inspecaoId:int}")]
        public async Task<ActionResult<InspecaoLaudo>> GetLaudo(int inspecaoId)
        {
            InspecaoLaudo resposta;
            resposta = await _service.InspecaoLaudo(inspecaoId);

            return resposta;
        }

    }
}
