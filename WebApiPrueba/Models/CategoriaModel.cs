using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.Models
{
    public class CategoriaModel
    {


        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Este Campo solo permite 10 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
