namespace WebApiPrueba.DataModel
{
    public class ProductoCategoriaModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
