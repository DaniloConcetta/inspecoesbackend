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

namespace Inspecoes.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/protheus/[controller]")]  //[Route("api/[controller]")] 
    public class OpProtheusController : ControllerBase
    {
        private readonly IOpPService _opPService;
        public OpProtheusController(IOpPService opPService)
        {
            _opPService = opPService;
        }

        [HttpPost("atualizar")]
        public async Task<ActionResult<bool>> PostMe(bool boolean)
        {
            var resposta = await _opPService.OpProtheus();
            return boolean;
        }
    }
}

