using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPrueba.DataModel
{
    public class CategoriaDataModel
    {
     

        [Key]
        [Column("CategoriaID")]
        public int CategoriaID { get; set; }


        public string Descripcion { get; set; } = string.Empty;
        [JsonProperty("Productos")]
        public virtual List<ProductoDataModel> Productos { get; set; } 

    }
}
