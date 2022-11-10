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
    public class SampleController : MainController
    {
        private readonly IFileUtil _FileUtil;

        public SampleController(IFileUtil fileUtil,
                                IMapper mapper,
                                INotifier notificador,
                                IUser user) : base(notificador, user)
        {
            _FileUtil = fileUtil;
        }

        [HttpGet("[action]")]
         public async Task<ActionResult<Object>> GetFileExcel(int id = 0)
        {
            HttpContext.Response.Headers.Add("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");
            this.Response.ContentType = "application/vnd.ms-excel";
            FileContentResult fileContentResulToExport;
            fileContentResulToExport = _FileUtil.GenerateExcelPergunta(id);
            return fileContentResulToExport;
        }
    
    }
}