using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.DataModel
{
    public class ProductDataModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Este Campo solo permite 50 caracteres")]
        public string Producto { get; set; } = string.Empty;


        //[Required]
        //[StringLength(10, MinimumLength = 10, ErrorMessage = "Este Campo solo permite 10 caracteres")]
        //public string Categoria { get; set; } = string.Empty;


        public List<CategoryDataModel> Categoria { get; set; }


        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Precio { get; set; }


    }
}
