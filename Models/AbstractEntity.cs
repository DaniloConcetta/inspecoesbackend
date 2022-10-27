using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspecoes.Models
{
    public abstract class AbstractEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Comment("Data Cadastro")] 
        public DateTime? DataCadastro { get; set; }

        [Comment("Data atualização")]
        public DateTime? DataAtualizacao { get; set; }

    }
}