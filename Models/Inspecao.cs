
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class Inspecao : AbstractEntity
    {
        public Inspecao() { }

        public String? User { get; set; }
        public int? Quantidade { get; set; }

        public int? StatusInspecaoId { get; set; }
        public int? OpId { get; set; }
        public int? GrupoPerguntaId { get; set; }

        //Relacionamentos
        [JsonIgnore]
        public StatusInspecao? statusInspecao { get; set; }

        [JsonIgnore]
        public Op? op { get; set; }

        [JsonIgnore]
        public GrupoPergunta? grupoPergunta { get; set; }
    }
}
