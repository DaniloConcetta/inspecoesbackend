using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Inspecoes.Interfaces;
using Inspecoes.Models;

namespace Inspecoes.Services
{
    public class OpPService : IOpPService
    {
        private readonly HttpClient _httpClient;
        private IOpRepository _opRepository;

        public OpPService(HttpClient httpClient,
                                    IOpRepository OpRepository
            )
        {
            _httpClient = httpClient;
            _opRepository = OpRepository;

        }

        public async Task<OpSC2> OpProtheus()
            {
            var opContent = "";  /*new StringContent(
                    content: JsonSerializer.Serialize(grupoProduto),
                    Encoding.UTF8,
                    mediaType: "application/json");*/

            var response = await _httpClient.GetAsync(requestUri: "http://172.16.10.187:6070/rest/api/v1/sfcopinspecao");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            
           
            OpSC2 opJson = JsonSerializer.Deserialize<OpSC2>(await response.Content.ReadAsStringAsync(), options);

            foreach (itemsSC2 item  in opJson.items)
            {
                Console.Write($"{item.id} ");
                Op op = new Op();
                op.Opnumero = item.opnumero;
                op.ProdutoCodigo = item.produtocodigo;
                op.ProdutoDescricao = item.produtodescricao;
                op.ProdutoGrupo = item.produtogrupo;
                op.Quantidade = item.quantidade;

                op.DataCadastro    = DateTime.Now;
                op.DataAtualizacao = DateTime.Now;

        Op opEncontrado = new Op();
                opEncontrado = await _opRepository.GetByCodigo(item.opnumero.ToString());

                if (opEncontrado == null) 
                {
                    op.Id = 0;
                    _opRepository.InsertNoAsync(op);
                } else {
                    op.Id = opEncontrado.Id;
                    op.DataCadastro = opEncontrado.DataCadastro;

                    _opRepository.Update(op);
                }
                ;
            }

            return opJson;

        }

    }
}
