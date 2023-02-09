using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPrueba.DataBaseContext;
using WebApiPrueba.DataModel;
using WebApiPrueba.Models;

namespace WebApiPrueba.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        public ProductoController(MyDatabaseContext dbcontext)
        {
            _dbContext= dbcontext;
        }




        [HttpGet]
        [Route("ListaProductos")]
        public async Task<IActionResult> ListaProductos()
        {
            return Ok(_dbContext.Productos.ToList());
        }

        [HttpPost]
        [Route("InsertaProducto")]
        public async Task<IActionResult> InsertaProducto(ProductoModel obj)
        {

            ProductoDataModel product = new ProductoDataModel();
            product.Id = Guid.NewGuid();
            product.Producto = obj.Producto;
            product.Precio=obj.Precio;
            product.Categoria=obj.Categoria;
            _dbContext.Productos.Add(product);
            _dbContext.SaveChanges();
 
             return Ok();
        }




    }
}
