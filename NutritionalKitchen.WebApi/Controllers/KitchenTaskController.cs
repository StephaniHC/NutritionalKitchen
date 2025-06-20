using Microsoft.AspNetCore.Mvc;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
