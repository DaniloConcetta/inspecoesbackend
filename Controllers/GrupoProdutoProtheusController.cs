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
    public class GruposProdutosProtheusController : ControllerBase
    {
        private readonly IGruposProdutoPService _gruposProdutoPService;
        public GruposProdutosProtheusController(IGruposProdutoPService gruposProdutoPService)
        {
            _gruposProdutoPService = gruposProdutoPService;
        }

        // GET: api/GrupoProdutoProtheus/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoProdutoProtheus>>> GetGruposProdutosProtheus()
        {
            var resposta = await _gruposProdutoPService.GrupoProdutoProtheus();
            /*
            if (resposta.items.Count>0)
            {
                Console.WriteLine(resposta);
            }*/

            //return await resposta. ;
            //return await resposta.ToList<GrupoProdutoProtheus>();
            return Ok();
        }

    }
}
