using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UrlShorter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class XYZController : ControllerBase
    {


        [HttpPost]
        public IActionResult GetURL([FromBody][Required] string URL)
        {
            URL 
            return Ok("Hola Mundo");
        }

    }
}
