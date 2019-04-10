using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {      
        [Display(Name = "Código")]
        public int Id { get; set; }        

        [Required]
        public string Nome { get; set; }
        
        public virtual List<Endereco> Enderecos { get; set; } // uma pessoa pode ter vários endereços     

        public MarcadorTextual Marcador { get; set; }

        public virtual List<Contato> Contatos { get; set; }
    }
}