using Inspecoes.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Inspecoes.Interfaces;

namespace Inspecoes.Utils
{
    public class FileUtil : IFileUtil
    {
        private readonly IPerguntaService _PerguntaService;

        public FileUtil(IPerguntaService perguntaService)
        {
            _PerguntaService = perguntaService;
        }
           
        public FileContentResult GenerateExcelPergunta(int id)
        {
            List<Pergunta> listModel = new List<Pergunta>();
            listModel = PerguntaRegistroFixo();
            listModel.AddRange(_PerguntaService.GetAll().Result);
            if (id > 0)
            {
                listModel.Add(_PerguntaService.GetById(id).Result);
            }

            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Id</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Descricao</font></b></td>");
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
            return new FileContentResult(temp, "application/vnd.ms-excel");
        }

        private List<Pergunta> PerguntaRegistroFixo()
        {
            List<Pergunta> recordobj = new List<Pergunta>();
            recordobj.Add(new Pergunta { Id = 1, Descricao = "Registro fixo1" });
            recordobj.Add(new Pergunta { Id = 2, Descricao = "Registro fixo2" });
            return recordobj;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
