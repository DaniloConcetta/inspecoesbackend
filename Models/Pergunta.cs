using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class Pergunta : AbstractEntity
    {
        public Pergunta() { }

        /*[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Codigo { get; set; }*/
        
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? AcaoSim { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? AcaoNao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? LaudoFinal { get; set; }

        public int? TipoPerguntaId { get; set; }
        
        //Relacionamentos
        [JsonIgnore]
        public TipoPergunta? TipoPergunta { get; set; }

        [JsonIgnore]
        public ICollection<GrupoPerguntaPergunta>? GruposPerguntas { get; set; } = new HashSet<GrupoPerguntaPergunta>();

    }
}
