using Inspecoes.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Inspecoes.Interfaces;
using IronPdf;
using OfficeOpenXml;

namespace Inspecoes.Utils
{
    public class FileUtil : IFileUtil
    {
        private readonly IPerguntaService _PerguntaService;
        private readonly ILogger<FileUtil> _logger;
        public FileUtil(ILogger<FileUtil> logger,
                        IPerguntaService perguntaService)
        {
            _logger = logger;
            _PerguntaService = perguntaService;
        }

        public FileContentResult GenerateHtmlPergunta(int id)
        {
            List<Pergunta> listModel = new List<Pergunta>();
            listModel = PerguntaRegistroFixo();
            listModel.AddRange(_PerguntaService.GetAll().Result);
            if (id > 0)
            {
                listModel.Add(_PerguntaService.GetById(id).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Identificação</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Descrição</font></b></td>");
            str.Append("</tr>");
            foreach (Pergunta model in listModel)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Id.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Descricao?.ToString() + "</font></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
    
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return new FileContentResult(temp, "application/html");
        }
        private List<Pergunta> PerguntaRegistroFixo()
        {
            List<Pergunta> recordobj = new List<Pergunta>();
            recordobj.Add(new Pergunta { Id = 1, Descricao = "Conteúdo fixo1 não josé" });
            recordobj.Add(new Pergunta { Id = 2, Descricao = "Conteúdo fixo2 a, á, à, ou há?" });
            recordobj.Add(new Pergunta { Id = 3, Descricao = "Conteúdo fixo3 a, á, à, ou há?" });
            return recordobj;
        }

        public FileContentResult GeneratePdfPergunta()
        {
            var renderer = new HtmlToPdf();
            PdfDocument pdf = renderer.RenderHtmlAsPdf("<h1>This is test file</h1>");
            return new FileContentResult(pdf.BinaryData, "application/pdf");
        }

        public FileContentResult GenerateXlsxSample()
        {
            List<Pergunta> perguntas = PerguntaRegistroFixo();
            ExcelPackage Ep = new ExcelPackage();
            
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Id";
            Sheet.Cells["B1"].Value = "Descrição";
            int row = 2;
            foreach (var pergunta in perguntas)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = pergunta.Id;
                Sheet.Cells[string.Format("B{0}", row)].Value = pergunta.Descricao;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            return new FileContentResult(Ep.GetAsByteArray(), "application/excel");
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
