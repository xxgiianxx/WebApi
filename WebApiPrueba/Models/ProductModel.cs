using System.ComponentModel.DataAnnotations;

namespace WebApiPrueba.Models
{
    public class ProductModel
    {
            
        public string Producto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
