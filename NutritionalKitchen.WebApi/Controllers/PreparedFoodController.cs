using Microsoft.AspNetCore.Mvc;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparedFoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
