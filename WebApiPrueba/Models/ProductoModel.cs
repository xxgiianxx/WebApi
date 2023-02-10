using System.ComponentModel.DataAnnotations;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public int CategoriaID { get; set; }



    }
}
