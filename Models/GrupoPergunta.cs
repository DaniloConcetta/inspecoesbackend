
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class GrupoPergunta : AbstractEntity
    {
        public GrupoPergunta() { }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Codigo { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }


        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Observacao { get; set; }

        //Relacionamentos
        [JsonIgnore]
        public ICollection<GrupoPerguntaPergunta>? GrupoPerguntaPerguntas { get; set; } = new HashSet<GrupoPerguntaPergunta>();

        [JsonIgnore]
        public ICollection<GrupoPerguntaGrupoProduto>? GrupoPerguntaGruposProdutos { get; set; } = new HashSet<GrupoPerguntaGrupoProduto>();

        [NotMapped]
        public virtual ICollection<Pergunta> Perguntas { get; set; }

        [NotMapped]
        public virtual ICollection<GrupoProduto> GruposProdutos { get; set; }
    }
}
