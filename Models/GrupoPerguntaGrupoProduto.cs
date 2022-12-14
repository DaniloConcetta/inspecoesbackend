using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class GrupoPerguntaGrupoProduto : AbstractEntity
    {
        public GrupoPerguntaGrupoProduto() { }

        [JsonIgnore]
        public GrupoProduto? GrupoProduto { get; set; }
        public int GrupoProdutoId { get; set; }

        [JsonIgnore]
        public GrupoPergunta? GrupoPergunta { get; set; }
        public int GrupoPerguntaId { get; set; }

    }
}
