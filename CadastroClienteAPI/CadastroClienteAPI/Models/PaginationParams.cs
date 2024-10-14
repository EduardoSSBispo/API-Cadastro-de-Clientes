using System.ComponentModel.DataAnnotations;

namespace CadastroClienteAPI.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(1, 50, ErrorMessage = "Máximo de 50 itens por página")]
        public int PageSize { get; set; }
    }
}
