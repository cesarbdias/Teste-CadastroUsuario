using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCadastro.Models
{
    public class DetalheUsuarioViewModels
    {
        [Key]
        public int IdDetalheUsuario { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}