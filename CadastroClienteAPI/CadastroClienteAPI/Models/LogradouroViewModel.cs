using System.ComponentModel.DataAnnotations;

namespace CadastroClienteAPI.Models
{
    public class LogradouroViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }
    }
}
