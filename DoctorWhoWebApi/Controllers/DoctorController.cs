using Microsoft.AspNetCore.Mvc;

namespace DoctorWhoWebApi.Controllers
{
    [ApiController]
    [Route("/doctors")]
    public class DoctorController : Controller
    {
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok();
        }
    }
}
