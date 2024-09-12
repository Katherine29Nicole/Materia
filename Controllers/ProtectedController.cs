using Microsoft.AspNetCore.Mvc;


namespace KNFU12092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }
        [HttpPost]
        public IActionResult Post(string name, string lasteName)
        {
            data.Add(new { name, lasteName });
            return Ok();
        }
    };
}