using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPrueba.DataBaseContext;
using WebApiPrueba.DataModel;
using WebApiPrueba.Models;

namespace WebApiPrueba.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        public ProductController(MyDatabaseContext dbcontext)
        {
            _dbContext= dbcontext;
        }


        [HttpGet]
        [Route("GetProductList")]
        public async Task<IActionResult> GetProductList()
        {
            return Ok(_dbContext.Products.ToList());
        }

        [HttpPost]
        [Route("PostProductList")]
        public async Task<IActionResult> PostProduct(ProductModel obj)
        {

            ProductDataModel product = new ProductDataModel();
            product.Id = Guid.NewGuid();
            product.Producto = obj.Producto;
            product.Precio=obj.Precio;
            product.Categoria=obj.Categoria;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
 
             return Ok();
        }


    }
}
