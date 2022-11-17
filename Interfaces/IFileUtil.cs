using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspecoes.DTOs;
using Inspecoes.Models;
using Inspecoes.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Inspecoes.Interfaces
{
    public interface IFileUtil : IDisposable
    {

        FileContentResult GenerateHtmlQuestionario(int id);
        FileContentResult GenerateHtmlLaudo(int id);

        FileContentResult GenerateXlsxQuestionario(int id);
        FileContentResult GenerateXlsxLaudo(int id);

        FileContentResult GeneratePdfQuestionario(int id);
        FileContentResult GeneratePdfLaudo(int id);

        /*
                FileContentResult GenerateHtmlPergunta(int id);
                FileContentResult GeneratePdfPergunta();
                FileContentResult GenerateXlsxSample();
        */
    }
}