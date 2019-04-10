using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    [Table("Contato")]
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Pessoa")]
        public int IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public string Valor { get; set; }

        public TipoContato Tipo { get; set; }
    }
}