using System.ComponentModel.DataAnnotations;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.Models
{
    public class ProductModel
    {
            
        public string Producto { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public List<CategoryDataModel> Categoria { get; set; }
    }
}
