using System; 

namespace NutritionalKitchen.Infrastructure.StoredModel.Entities
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
