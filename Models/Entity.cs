using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspecoes.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}