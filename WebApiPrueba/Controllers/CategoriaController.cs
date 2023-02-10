using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using WebApiPrueba.DataBaseContext;
using WebApiPrueba.DataModel;
using WebApiPrueba.Models;

namespace WebApiPrueba.Controllers
{


    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {


        private readonly MyDatabaseContext _dbContext;
        public CategoriaController(MyDatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
        }



        [HttpGet]
        [Route("ListaCategorias")]
        public async Task<IActionResult> ListaCategorias()
        {
            var result = _dbContext.Categorias.ToList();
            if (result.Count <= 0)
            {
                return NotFound();
            }
            //return await _dbContext.Productos.Include(x => x.categoria).ToListAsync();
            return Ok(result);
        }


        [Route("Obtener/{id:int}")]
        [HttpGet]
        public async Task<ActionResult <CategoriaDataModel>> Obtener(int id)
        {
            var categoria=await _dbContext.Categorias.FirstOrDefaultAsync(x=> x.CategoriaID== id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpPost]
        [Route("InsertaCategoria")]
        public async Task<IActionResult> InsertaCategoria(CategoriaModel obj)
        {
            var existeCategoria = await _dbContext.Categorias.AnyAsync(x => x.Descripcion == obj.Descripcion);

            if (existeCategoria)
            {

                return BadRequest($"La Categoria ya existe:{obj.Descripcion}");
            }


            CategoriaDataModel categoria = new CategoriaDataModel();
            categoria.CategoriaID = await BuscaMaximo();
            categoria.Descripcion = obj.Descripcion;
            _dbContext.Categorias.Add(categoria);
            _dbContext.SaveChanges();
            return Ok();


        }

        [HttpGet]
        [Route("ObtineMaximoId")]
        public async Task<int> BuscaMaximo()
        {
            int result = 0;

            var Id = _dbContext.Categorias.OrderByDescending(x => x.CategoriaID).FirstOrDefault();

            if (Id == null)
            {
                result = 1;
            }
            else
            {
                result = 1 + Id.CategoriaID;
            }
            return result;

        }
    }
}
