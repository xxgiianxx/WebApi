using System.ComponentModel.DataAnnotations;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.Models
{
    public class ProductoModel
    {
            
        public string Producto { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public List<CategoriaDataModel> Categoria { get; set; }
    }
}
