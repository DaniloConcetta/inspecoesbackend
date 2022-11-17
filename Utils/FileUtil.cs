using Inspecoes.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Inspecoes.Interfaces;
using Inspecoes.Services;

namespace Inspecoes.Utils
{
    public class FileUtil : IFileUtil
    {
        private readonly IInspecaoItemService _InspecaoItemService;
        private readonly IInspecaoLaudoService _InspecaoLaudoService;
        private readonly IInspecaoItemRepository _InspecaoItemRepository;

        public FileUtil(IInspecaoItemService inspecaoItemService, IInspecaoItemRepository inspecaoItemRepository, IInspecaoLaudoService inspecaoLaudoService)
        {
            _InspecaoLaudoService = inspecaoLaudoService;
            _InspecaoItemService = inspecaoItemService;
            _InspecaoItemRepository = inspecaoItemRepository;
        }

        public FileContentResult GenerateExcelQuestionario(int inspecaoid)
        {
            List<InspecaoItem> listModel = new List<InspecaoItem>();
            listModel = TopoQuestionarioFixo();
            //listModel.AddRange(_InspecaoItemService.GetAll().Result);
            if (inspecaoid > 0)
            {
                listModel.AddRange(_InspecaoItemRepository.GetByIdInspecao(inspecaoid).Result);
            }

            StringBuilder str = new StringBuilder();
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
            return new FileContentResult(temp, "application/vnd.ms-excel");
        }

        public FileContentResult GenerateExcelLaudo(int inspecaoid)
        {
            List<InspecaoLaudo> listModel = new List<InspecaoLaudo>();
            listModel = TopoLaudoFixo();
            //listModel.AddRange(_InspecaoLaudoService.InspecaoLaudo(inspecaoid).Result);

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
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
