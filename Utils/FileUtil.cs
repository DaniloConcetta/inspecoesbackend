using Inspecoes.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Inspecoes.Interfaces;
using IronPdf;
using OfficeOpenXml;
using Inspecoes.Services;

namespace Inspecoes.Utils
{
    public class FileUtil : IFileUtil
    {
        private readonly IInspecaoItemService _InspecaoItemService;
        private readonly IInspecaoLaudoService _InspecaoLaudoService;
        private readonly IInspecaoItemRepository _InspecaoItemRepository;
        private readonly ILogger<FileUtil> _logger;

        public FileUtil(ILogger<FileUtil> logger, 
                        IInspecaoItemService inspecaoItemService, 
                        IInspecaoItemRepository inspecaoItemRepository, 
                        IInspecaoLaudoService inspecaoLaudoService)
        {
            _InspecaoLaudoService = inspecaoLaudoService;
            _InspecaoItemService = inspecaoItemService;
            _InspecaoItemRepository = inspecaoItemRepository;
            _logger = logger;
        }

        public FileContentResult GenerateHtmlQuestionario(int inspecaoid)
        {
            List<InspecaoItem> listModel = new List<InspecaoItem>();
            listModel = TopoQuestionarioFixo();
            if (inspecaoid > 0)
            {
                listModel.AddRange(_InspecaoItemRepository.GetByIdInspecao(inspecaoid).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            str.Append("<table border=`" + "1px" + "`b>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3></font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Questionario</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3></font></b></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Id</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Descricao</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Resposta</font></b></td>");
            str.Append("</tr>");
            foreach (InspecaoItem model in listModel)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.PerguntaId.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.PerguntaDescricao?.ToString() + "</font></td>");
                if (model.Sim)
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + "Sim" + "</font></td>");
                }
                else
                {
                    if (model.Nao)
                    {
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + "Nao" + "</font></td>");
                    }
                    else
                    {
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Descritivo.ToString() + "</font></td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
    
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return new FileContentResult(temp, "application/html");
        }

        public FileContentResult GenerateHtmlLaudo(int inspecaoid)
        {
            List<InspecaoLaudo> listModel = new List<InspecaoLaudo>();
            listModel = TopoLaudoFixo();

            if (inspecaoid > 0)
            {
                listModel.Add(_InspecaoLaudoService.InspecaoLaudo(inspecaoid).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=6>Laudo</font></b></td>");
            //str.Append("<td><b><font face=Arial Narrow size=3>Descricao</font></b></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Estado</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Ocorrencia</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Recomendacao</font></b></td>");
            str.Append("</tr>");
            foreach (InspecaoLaudo model in listModel)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.EstadoInspecao.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Texto?.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Recomendacao?.ToString() + "</font></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");

            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return new FileContentResult(temp, "application/vnd.ms-excel");
        }
        private List<InspecaoItem> TopoQuestionarioFixo()
        {
            List<InspecaoItem> recordobj = new List<InspecaoItem>();
            recordobj.Add(new InspecaoItem 
            { 
                PerguntaId = 0, 
                PerguntaDescricao = "",
                Descritivo = ""
            });
            //recordobj.Add(new Pergunta { Id = 2, Descricao = "Registro fixo2" });
            return recordobj;
        }
        private List<InspecaoLaudo> TopoLaudoFixo()
        {
            List<InspecaoLaudo> recordobj = new List<InspecaoLaudo>();
            recordobj.Add(new InspecaoLaudo
            {
                EstadoInspecao = "",
                Texto = "",
                Recomendacao =""
            });

            return recordobj;
        }

        public FileContentResult GenerateXlsxQuestionario(int inspecaoid)
        {
            List<InspecaoItem> listModel = new List<InspecaoItem>();
            //listModel = TopoQuestionarioFixo();
            if (inspecaoid > 0)
            {
                listModel.AddRange(_InspecaoItemRepository.GetByIdInspecao(inspecaoid).Result);
            }
            
            ExcelPackage Ep = new ExcelPackage();

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Questionario");
            Sheet.Cells["A1"].Value = "Id";
            Sheet.Cells["B1"].Value = "Descrição";
            Sheet.Cells["C1"].Value = "Resposta";
            int row = 2;
            foreach (var inspecaoitem in listModel)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = inspecaoitem.PerguntaId;
                Sheet.Cells[string.Format("B{0}", row)].Value = inspecaoitem.PerguntaDescricao;
                if (inspecaoitem.Sim)
                {
                    Sheet.Cells[string.Format("C{0}", row)].Value = "Sim";
                }
                else
                {
                    if (inspecaoitem.Nao)
                    {
                        Sheet.Cells[string.Format("C{0}", row)].Value = "Não";
                    }
                    else
                    {
                        Sheet.Cells[string.Format("C{0}", row)].Value = inspecaoitem.Descritivo.ToString();
                    }
                }
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            return new FileContentResult(Ep.GetAsByteArray(), "application/excel");
        }

        public FileContentResult GenerateXlsxLaudo(int inspecaoid)
        {
            List<InspecaoLaudo> listModel = new List<InspecaoLaudo>();
            listModel = TopoLaudoFixo();

            if (inspecaoid > 0)
            {
                listModel.Add(_InspecaoLaudoService.InspecaoLaudo(inspecaoid).Result);
            }

            ExcelPackage Ep = new ExcelPackage();

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Laudo");
            Sheet.Cells["A1"].Value = "Estado";
            Sheet.Cells["B1"].Value = "Ocorrência";
            Sheet.Cells["C1"].Value = "Recomendação";
            int row = 2;
            foreach (var inspecaolaudo in listModel)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = inspecaolaudo.EstadoInspecao;
                Sheet.Cells[string.Format("B{0}", row)].Value = inspecaolaudo.Texto;
                Sheet.Cells[string.Format("C{0}", row)].Value = inspecaolaudo.Recomendacao;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            return new FileContentResult(Ep.GetAsByteArray(), "application/excel");
        }

        public FileContentResult GeneratePdfQuestionario(int inspecaoid)
        {
            var renderer = new HtmlToPdf();
            List<InspecaoItem> listModel = new List<InspecaoItem>();
            listModel = TopoQuestionarioFixo();
            if (inspecaoid > 0)
            {
                listModel.AddRange(_InspecaoItemRepository.GetByIdInspecao(inspecaoid).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            str.Append("<table border=`" + "1px" + "`b>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3></font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Questionario</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3></font></b></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Id</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Descricao</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Resposta</font></b></td>");
            str.Append("</tr>");
            foreach (InspecaoItem model in listModel)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.PerguntaId.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.PerguntaDescricao?.ToString() + "</font></td>");
                if (model.Sim)
                {
                    str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + "Sim" + "</font></td>");
                }
                else
                {
                    if (model.Nao)
                    {
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + "Nao" + "</font></td>");
                    }
                    else
                    {
                        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Descritivo.ToString() + "</font></td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            PdfDocument pdf = renderer.RenderHtmlAsPdf(str.ToString());

            return new FileContentResult(pdf.BinaryData, "application/pdf");
        }

        public FileContentResult GeneratePdfLaudo(int inspecaoid)
        {
            var renderer = new HtmlToPdf();
            List<InspecaoLaudo> listModel = new List<InspecaoLaudo>();
            listModel = TopoLaudoFixo();

            if (inspecaoid > 0)
            {
                listModel.Add(_InspecaoLaudoService.InspecaoLaudo(inspecaoid).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=6>Laudo</font></b></td>");
            //str.Append("<td><b><font face=Arial Narrow size=3>Descricao</font></b></td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Estado</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Ocorrencia</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Recomendacao</font></b></td>");
            str.Append("</tr>");
            foreach (InspecaoLaudo model in listModel)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.EstadoInspecao.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Texto?.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + model.Recomendacao?.ToString() + "</font></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");

            PdfDocument pdf = renderer.RenderHtmlAsPdf(str.ToString());

            return new FileContentResult(pdf.BinaryData, "application/pdf");
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
