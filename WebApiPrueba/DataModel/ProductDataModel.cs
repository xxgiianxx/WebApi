using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.DataModel
{
    public class ProductDataModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
        public string Producto { get; set; } = string.Empty;


        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
        public string Categoria { get; set; } = string.Empty;


        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Precio { get; set; }


    }
}
