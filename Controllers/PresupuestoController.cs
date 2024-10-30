using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_Trigo00.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly PresupuestoRepository _presupuestoRepository;
    private readonly ProductoRepository _productoRepository;

    private readonly ILogger<PresupuestoController> _logger;

    public PresupuestoController(ILogger<PresupuestoController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult CrearPresupuesto([FromBody] Presupuesto presupuesto)
    {
        _presupuestoRepository.CrearPresupuesto(presupuesto);
        return Ok("Presupuesto creado correctamente");
    }

    [HttpPost("{id}/ProductoDetalle")]
    public IActionResult AgregarProductoDetalle(int idPresupuesto, [FromBody] PresupuestoDetalle pDetalle)
    {
        
        _presupuestoRepository.AgregarProductoAPresupuesto(idPresupuesto, pDetalle.Producto.IdProducto, pDetalle
        .Cantidad);
        return NoContent();

    }

    [HttpGet]
    public IActionResult ListarPresupuestos()
    {
        var presupuestos = _presupuestoRepository.ListarPresupuestos();
        return Ok(presupuestos);
    }

}
