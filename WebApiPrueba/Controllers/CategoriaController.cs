using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using WebApiPrueba.DataBaseContext;
using WebApiPrueba.DataModel;

namespace WebApiPrueba.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {


        //private readonly MyDatabaseContext _dbContext;
        //public CategoriaController(MyDatabaseContext dbcontext)
        //{
        //    _dbContext = dbcontext;
        //}

        //public async Task<ActionResult<ProductoDataModel>> get()
        //{


        //    return await _dbContext.
        //}



        //[HttpGet]
        //[Route("ListaProductos")]
        //public async Task<IActionResult> ListaProductos()
        //{
        //    return Ok(_dbContext.Productos.ToList());
        //}

        //[HttpPost]
        //[Route("InsertaProducto")]
        //public async Task<IActionResult> InsertaProducto(ProductoModel obj)
        //{

        //    ProductoDataModel product = new ProductoDataModel();
        //    product.Id = Guid.NewGuid();
        //    product.Producto = obj.Producto;
        //    product.Precio = obj.Precio;
        //    product.Categoria = obj.Categoria;
        //    _dbContext.Productos.Add(product);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}


    }
}
