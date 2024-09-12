using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace KNFU12092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    { 
     private static List<Nota> data = new List<Nota>();

    // Permitir acceso anónimo para obtener todas las notas
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(data);
    }

    // Requiere autenticación para crear una nueva nota
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] Nota nota)
    {
        if (nota == null)
        {
            return BadRequest("La nota no puede ser nula.");
        }

        data.Add(nota);
        return CreatedAtAction(nameof(Get), nota);
    }

    // Requiere autenticación para eliminar una nota
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var nota = data.Find(n => n.Id == id);
        if (nota == null)
        {
            return NotFound();
        }

        data.Remove(nota);
        return NoContent();
    }
}

public class Nota
{
    public int Id { get; set; }
    public string NombreAlumno { get; set; }
    public string Calificacion { get; set; }
}
}