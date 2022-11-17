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
         public async Task<ActionResult<Object>> GetQuestionarioHtml(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Questionario" + DateTime.Now.Year.ToString() + ".html");
            this.Response.ContentType = "application/html";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateHtmlQuestionario(inspecaoid);
            return fileContentResulToExport;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetLaudoHtml(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Laudo" + DateTime.Now.Year.ToString() + ".html");
            this.Response.ContentType = "application/html";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateHtmlLaudo(inspecaoid);
            return fileContentResulToExport;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetQuestionarioXlsx(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Questionario" + DateTime.Now.ToString() + ".xlsx");
            this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateXlsxQuestionario(inspecaoid);
            return fileContentResulToExport;
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetLaudoXlsx(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Laudo" + DateTime.Now.ToString() + ".xlsx");
            this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateXlsxLaudo(inspecaoid);
            return fileContentResulToExport;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetQuestionarioPdf(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Questionario" + DateTime.Now.ToString() + ".pdf");
            this.Response.ContentType = "application/pdf";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GeneratePdfQuestionario(inspecaoid);
            return fileContentResulToExport;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Object>> GetLaudoPdf(int inspecaoid)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Laudo" + DateTime.Now.ToString() + ".pdf");
            this.Response.ContentType = "application/pdf";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GeneratePdfLaudo(inspecaoid);
            return fileContentResulToExport;
        }
    }
}