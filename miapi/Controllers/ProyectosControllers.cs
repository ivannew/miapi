using miapi.Models;
using miapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace miapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly ILogger<ProyectosController> _logger;

    private readonly ProyectosServices _proyectosServices;

    public ProyectosController(ILogger<ProyectosController> logger, ProyectosServices proyectosServices)
    {
        _logger = logger;
        _proyectosServices = proyectosServices;
    }

    ///Obtener todos los Sensores
    [HttpGet]
    public async Task<IActionResult> GetProyecto()
    {
        var proyectos = await _proyectosServices.GetAsync();
        return Ok(proyectos);
    }

    ///Obtener Sensor por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProyectoById(string Id)
    {
        return Ok(await _proyectosServices.GetProyectoById(Id));
    }

    ///Crear Sensor
    [HttpPost]
    public async Task<IActionResult> CreateProyecto([FromBody] Proyectos proyectos)
    {
        if (proyectos == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");

        await _proyectosServices.InsertProyecto(proyectos);

        return Created("Created", true);
    }

    ///Actualizar Sensor
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateProyecto([FromBody] Proyectos proyectos, string Id)
    {
        if (proyectos == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");
        //motor.Id = Id;

        await _proyectosServices.InsertProyecto(proyectos);
        return Created("Created", true);
    }

    ///Eliminar Sensor
    [HttpDelete]
    public async Task<IActionResult> DeleteProyecto(string Id)
    {
        await _proyectosServices.DeleteProyecto(Id);
        return NoContent();
    }
}



