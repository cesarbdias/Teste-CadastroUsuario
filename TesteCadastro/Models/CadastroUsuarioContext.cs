using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TesteCadastro.Models
{
    public class CadastroUsuarioContext : DbContext
    {

        public CadastroUsuarioContext(): base("Name=CadastroUsuarioContext")
        {

        }

        public DbSet<UsuarioViewModels> Usuario { get; set; }

        public DbSet<DetalheUsuarioViewModels> DetalheUsario { get; set; }
    }
}