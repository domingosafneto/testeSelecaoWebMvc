using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contatos.Models
{
    public class BancoContext : DbContext
    {
        public BancoContext() : base("Banco")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}