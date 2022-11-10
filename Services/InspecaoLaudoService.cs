using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Inspecoes.Interfaces;
using Inspecoes.Models;

namespace Inspecoes.Services
{
    public class InspecaoLaudoService : IInspecaoLaudoService
    {
     
      private IInspecaoItemRepository _inspecaoItemRepository;
      private IPerguntaRepository _perguntaRepository;

        public InspecaoLaudoService( IInspecaoItemRepository inspecaoItemRepository, 
                                     IPerguntaRepository perguntaRepository )
        {
            _inspecaoItemRepository = inspecaoItemRepository;
            _perguntaRepository = perguntaRepository;
        }

        public async Task<InspecaoLaudo> InspecaoLaudo(int inspecaoId)
            {

            Boolean lAceite     = true;
            string cTextoSim    = "";
            string cTextoNao    = "";
            string cTextoBase   = "";
            string cTextoRecomendado = "";
            string cTextoConclusao   = "";
            InspecaoLaudo inspecaoLaudo = new InspecaoLaudo(); 

            List<InspecaoItem> inspecaoItens = new List<InspecaoItem>();
            inspecaoItens = await _inspecaoItemRepository.GetByIdInspecao(inspecaoId);

            foreach (InspecaoItem item in inspecaoItens)
            {
                if (item.Nao == true)
                {
                    lAceite = false;
                }

                if (item.Nao == true)
                {
                    Pergunta pergunta = new Pergunta();
                    pergunta = await _perguntaRepository.GetById(item.PerguntaId);

                    cTextoNao += pergunta.LaudoNao;
                } else
                {
                    Pergunta pergunta = new Pergunta();
                    pergunta = await _perguntaRepository.GetById(item.PerguntaId);

                    cTextoSim += pergunta.LaudoSim;
                }
            }

            if (lAceite == true)
            {
                cTextoBase = "Produto aprovado na inspeção de qualidade!";
                //cTextoSim
                cTextoRecomendado = "Ações Recomendadas:";
                cTextoConclusao = "Proceder Entrega.";

                inspecaoLaudo.EstadoInspecao = "Aprovada";
                inspecaoLaudo.Texto = "";
                inspecaoLaudo.Recomendacao = cTextoConclusao;
            }
            else
            {
                cTextoBase = "Produto recusado na inspeção de qualidade pelos seguintes motivos:";
                //cTextoNao
                cTextoRecomendado = "Ações Recomendadas:";
                cTextoConclusao = "Desmonte da OP";
                
                inspecaoLaudo.EstadoInspecao = "Reprovada";
                inspecaoLaudo.Texto = cTextoNao;
                inspecaoLaudo.Recomendacao = cTextoConclusao;
            }

            return inspecaoLaudo;
        }

    }
}
