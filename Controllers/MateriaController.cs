using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace KNFU12092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MateriaController : ControllerBase
    {
      
            private static List<Materia> data = new List<Materia>();

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(data);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Materia materia)
            {
                data.Add(materia);
                return CreatedAtAction(nameof(Get), materia);
            }


            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var materia = data.Find(m => m.Id == id);
                if (materia == null)
                {
                    return NotFound();
                }

                data.Remove(materia);
                return NoContent();
            }
        }

        public class Materia
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }
    }
