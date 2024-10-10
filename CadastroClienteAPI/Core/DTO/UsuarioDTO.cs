using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class UsuarioDTO
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string Senha { get; set; }
    }
}
