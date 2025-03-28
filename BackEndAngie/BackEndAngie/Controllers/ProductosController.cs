using BackEndAngie.Models;
using BackEndAngie.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _productoService;

    public ProductosController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    //PRODUCTOS
    public async Task<ActionResult<List<Productos>>> ObtenerProductos()
    {
        var productos = await _productoService.ObtenerProductos();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Productos>> ObtenerProductoPorId(Guid id)
    {

        var producto = await _productoService.ObtenerProductoPorId(id);
        if (producto == null) return NotFound("Producto no encontrado");
        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult> CrearProducto([FromBody] Productos producto)
    {
        if (producto == null)
        {
            return BadRequest("Datos del producto vienen vacíos");
        }
        var nuevoProducto = await _productoService.CrearProducto(producto);
        return Ok(nuevoProducto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarProducto(Guid id, [FromBody] Productos productoActualizado)
    {
        if (productoActualizado == null)
        {
            return BadRequest("Datos del producto vienen vacíos");
        }

        var response = await _productoService.ActualizarProducto(id, productoActualizado);

        if (!response)
        {
            return NotFound("Producto no encontrado en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarProducto(Guid id)
    {
        var response = await _productoService.EliminarProducto(id);
        if (response == false)
        {
            return NotFound("Producto no encontrado en base de datos");
        }
        return NoContent();
    }
}
