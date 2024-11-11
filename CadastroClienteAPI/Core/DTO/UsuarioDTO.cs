using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

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
