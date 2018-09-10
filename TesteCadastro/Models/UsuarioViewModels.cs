using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteCadastro.Models
{
    public class UsuarioViewModels
    {
        public UsuarioViewModels()
        {
            DetalheUsuario = new DetalheUsuarioViewModels();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public virtual DetalheUsuarioViewModels DetalheUsuario { get; set; }
    }
}