using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiPrueba.Models;

namespace WebApiPrueba.DataModel
{
    public  class ProductoDataModel
    {

 

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Este Campo solo permite 50 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("CategoriaID")]
        public int CategoriaId { get; set; }


        [Required]
        public int Cantidad{ get; set; }


        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Precio { get; set; }


        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CategoriaID")]
        public virtual CategoriaDataModel categoria { get; set; }


       


    }
}
