using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspecoes.Models
{
    public abstract class Entity
    {
        //protected Entity()
        //{            Id = Id. id.New();        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}