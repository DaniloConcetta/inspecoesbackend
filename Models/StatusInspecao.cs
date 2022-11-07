using System.ComponentModel.DataAnnotations;

namespace Inspecoes.Models
{
    public class StatusInspecao : AbstractEntity
    {

        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

    }
}
