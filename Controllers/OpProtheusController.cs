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

namespace Inspecoes.Controllers
{
    [Route("api/protheus/[controller]")]
    [ApiController]
    public class OpProtheusController : ControllerBase
    {
        private readonly IOpPService _opPService;
        public OpProtheusController(IOpPService opPService)
        {
            _opPService = opPService;
        }

        // GET: api/GrupoProdutoProtheus/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpProtheus>>> GetOpProtheus()
        {
            var resposta = await _opPService.OpProtheus();

            return Ok();
        }

    }
}
