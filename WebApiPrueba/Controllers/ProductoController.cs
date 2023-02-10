using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPrueba.DataBaseContext;
using WebApiPrueba.DataModel;
using WebApiPrueba.Models;

namespace WebApiPrueba.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<ProductoDataModel>>> ListaProducto()
        {


            return await _dbContext.Productos.Include(x => x.categoria).ToListAsync();
        }


        [HttpGet]
        [Route("ListaProductoCategoria")]
        public async Task<ActionResult<List<ProductoCategoriaModel>>> ListaProductoCategoria()
        {


            var query = from a in _dbContext.Productos
                        join s in _dbContext.Categorias on a.CategoriaId equals s.CategoriaID
                        select new ProductoCategoriaModel
                        {
                            Id = a.Id,
                            Descripcion = a.Descripcion,
                            Precio = a.Precio,
                            Categoria = s.Descripcion,
                            Cantidad = a.Cantidad,
                            CategoriaID = a.CategoriaId

                        };

            return  query.ToList();
        }

        [HttpGet]
        [Route("ObtenerProductoCategoria/{Id:int}")]
        public async Task<ActionResult<ProductoCategoriaModel>> ListaProductoCategoriaCategoria(int Id)
        {


            var query = from a in _dbContext.Productos
                        join s in _dbContext.Categorias on a.CategoriaId equals s.CategoriaID
                        where a.Id == Id
                        select new ProductoCategoriaModel
                        {
                            Id = a.Id,
                            Descripcion = a.Descripcion,
                            Precio = a.Precio,
                            Categoria = s.Descripcion,
                            Cantidad = a.Cantidad,
                            CategoriaID = a.CategoriaId

                        };
            ProductoCategoriaModel obj =new  ProductoCategoriaModel();

            foreach (var item in query.ToList())
            {
                obj.Id = item.Id;
                obj.Descripcion = item.Descripcion;
                obj.CategoriaID = item.CategoriaID;
                obj.Cantidad = item.Cantidad;
                obj.Categoria = item.Categoria;
                obj.Precio = item.Precio;
            }

            return obj;
        }

        [Route("Obtener/{Id:int}")]
        [HttpGet]
        public async Task<ActionResult<ProductoDataModel>> Obtener(int Id)
        {
            var producto = await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == Id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }



        [HttpPost]
        [Route("InsertaProducto")]
        public async Task<ActionResult> InsertaProducto(ProductoModel obj)
        {
            var existeProducto = await _dbContext.Categorias.AnyAsync(x => x.CategoriaID == obj.CategoriaID);

            if(!existeProducto) {

                return BadRequest($"La Categoria con Id:{obj.CategoriaID}" +" No Existe");
            }

            ProductoDataModel product = new ProductoDataModel();
            int result=await BuscaMaximo();
            product.Id = result;
            product.Descripcion = obj.Descripcion;
            product.Precio=obj.Precio;
            product.CategoriaId=obj.CategoriaID;
            product.Cantidad = obj.Cantidad;
            _dbContext.Productos.Add(product);
            await _dbContext.SaveChangesAsync();
 
             return  Ok();
        }

        [Route("ModificarProducto/{Id:int}")]
        [HttpPut]
        public async Task<IActionResult> ModificarProducto(ProductoModel obj, int Id) {

            if (obj.Id != Id)
            {
                return BadRequest("El Id del Producto no coincide con el Id de la url");
            }

            ProductoDataModel product = new ProductoDataModel();
            product.Id = obj.Id;
            product.Descripcion = obj.Descripcion;
            product.Precio = obj.Precio;
            product.CategoriaId = obj.CategoriaID;
            product.Cantidad = obj.Cantidad;
            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [Route("EliminarProducto/{Id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int Id)
        {

            var existeProducto = await _dbContext.Productos.AnyAsync(x => x.Id == Id);
            if (!existeProducto)
            {
                return NotFound($"La Producto con Id:{Id}" + " No Existe");
            }

            _dbContext.Remove(new ProductoDataModel() { Id = Id });
            await _dbContext.SaveChangesAsync();    
            return Ok();
        }



        [HttpGet]
        [Route("ListaProductosId")]
        public async Task<ActionResult<List<ProductoDataModel>>> ListaProductoId(int Id)
        {
            return await _dbContext.Productos.Include(x => x.categoria).ToListAsync();
        }



        [HttpGet]
        [Route("ObtineMaximoId")]
        public async Task<int> BuscaMaximo()
        {
            int result = 0;

            var latestStudentRecord = _dbContext.Productos.OrderByDescending(x => x.Id).FirstOrDefault();

            if (latestStudentRecord == null)
            {
                result = 1;
            }
            else
            {
                result = 1 + latestStudentRecord.Id;
            }
            return result;

        }

    }
}
