using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class InspecaoItem : AbstractEntity
    {
        public InspecaoItem() { }

        public String? User { get; set; }
        public bool? Sim { get; set; }
        public bool? Nao { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public String? Descritivo { get; set; }

        public int PerguntaId { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? PerguntaDescricao { get; set; }

        public int InspecaoId { get; set; }

        [JsonIgnore]
        public Inspecao Inspecao { get; set; }
        
        [JsonIgnore]
        public Pergunta Pergunta { get; set; }

    }
}
