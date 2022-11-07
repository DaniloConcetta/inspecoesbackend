using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Inspecoes.Interfaces;
using Inspecoes.Models;

namespace Inspecoes.Services
{
    public class GruposProdutoPService : IGruposProdutoPService
    {
        private readonly HttpClient _httpClient;
        private IGrupoProdutoRepository _grupoProdutoRepository;

        public GruposProdutoPService(HttpClient httpClient,
                                    IGrupoProdutoRepository GrupoProdutoRepository
            )
        {
            _httpClient = httpClient;
            _grupoProdutoRepository = GrupoProdutoRepository;

        }

        public async Task<GrupoProdutoSBM> GrupoProdutoProtheus()
            {
            var grupoProdutoContent = "";  /*new StringContent(
                    content: JsonSerializer.Serialize(grupoProduto),
                    Encoding.UTF8,
                    mediaType: "application/json");*/

            var response = await _httpClient.GetAsync(requestUri: "http://172.16.10.187:6070/rest/api/v1/sfcgruposprodutos" );

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            
           
            GrupoProdutoSBM grupoProdutoJson = JsonSerializer.Deserialize<GrupoProdutoSBM>(await response.Content.ReadAsStringAsync(), options);

            foreach (itemsSBM item  in grupoProdutoJson.items)
            {
                Console.Write($"{item.id} ");
                GrupoProduto grupoProduto = new GrupoProduto();
                grupoProduto.Codigo = item.codigo;
                grupoProduto.Descricao = item.descricao;

                grupoProduto.DataCadastro    = DateTime.Now;
                grupoProduto.DataAtualizacao = DateTime.Now;

                GrupoProduto grupoProdutoEncontrado = new GrupoProduto();
                grupoProdutoEncontrado = await _grupoProdutoRepository.GetByCodigo(item.codigo.ToString());

                if (grupoProdutoEncontrado == null) 
                {
                    grupoProduto.Id = 0;
                    _grupoProdutoRepository.InsertNoAsync(grupoProduto);
                } else {
                    grupoProduto.Id = grupoProdutoEncontrado.Id;
                    grupoProduto.DataCadastro = grupoProdutoEncontrado.DataCadastro;

                    _grupoProdutoRepository.Update(grupoProduto);
                }
                ;
            }

            return grupoProdutoJson;

        }

    }
}
