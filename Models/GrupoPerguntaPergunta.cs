using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class GrupoPerguntaPergunta : AbstractEntity
    {
        public GrupoPerguntaPergunta() { }

        [JsonIgnore]
        public Pergunta? Pergunta { get; set; }
        public int PerguntaId { get; set; }

        [JsonIgnore]
        public GrupoPergunta? GrupoPergunta { get; set; }
        public int GrupoPerguntaId { get; set; }

    }
}
