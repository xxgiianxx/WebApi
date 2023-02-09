using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.DataModel
{
    public class CategoriaDataModel
    {

        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Este Campo solo permite 10 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        public int ProductoID { get; set; }

        public ProductoDataModel producto { get; set; }  


    }
}
