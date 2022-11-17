using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Inspecoes.Models;
using AutoMapper;
using Inspecoes.Interfaces;
using Inspecoes.Controllers;
using Inspecoes.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Inspecoes.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/[controller]")]
    public class RelatoriosController : MainController
    {
        private readonly IFileUtil _FileUtil;

        public RelatoriosController(IFileUtil fileUtil,
                                IMapper mapper,
                                INotifier notificador,
                                IUser user) : base(notificador, user)
        {
            _FileUtil = fileUtil;
        }

        [HttpGet("[action]")]
         public async Task<ActionResult<Object>> GetQuestionarioExcel(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Questionario" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateExcelQuestionario(inspecaoid);
            return fileContentResulToExport;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetLaudoExcel(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Laudo" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateExcelLaudo(inspecaoid);
            return fileContentResulToExport;
        }

    }
}