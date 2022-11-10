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
        FileContentResult GenerateExcelPergunta(int id);
    }
}