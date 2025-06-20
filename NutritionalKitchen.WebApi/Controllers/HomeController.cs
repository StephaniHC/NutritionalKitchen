using Microsoft.AspNetCore.Mvc;

namespace NutritionalKitchen.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("/swagger");
        }
    }
}
