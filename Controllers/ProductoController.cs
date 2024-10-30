using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_Trigo00.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoRepository _productoRepository;

    private readonly ILogger<ProductoController> _logger;

    public ProductoController(ILogger<ProductoController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("CrearProducto")]
    public IActionResult CrearProducto([FromBody] Producto producto)
    {
        Producto pro = _productoRepository.ObtenerProducto(producto.IdProducto);
        if(pro != null)
        {
            return BadRequest("El producto ya se encuentra en la lista");
        }
        _productoRepository.CrearProducto(producto);
        return Ok("Producto creado correctamente");
    }

    [HttpGet]
    [Route("ListaProductos")]
    public IActionResult ListarProductos()
    {
        var productos = _productoRepository.ListarProductos();
        return Ok(productos);
    }

    [HttpPut("{id}")]
    public IActionResult ModificarProducto(int id, [FromBody] Producto producto)
    {
        _productoRepository.ModificarProducto(id, producto);
        return NoContent();
    }

    

    
}
