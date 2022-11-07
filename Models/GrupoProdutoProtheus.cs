using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Inspecoes.Models
{
    public class GrupoProdutoProtheus : Entity
    {

        public GrupoProdutoProtheus() { }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Codigo { get; set; }
        
        //[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }

    }
}
