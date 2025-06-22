using MediatR;
using Microsoft.AspNetCore.Mvc; 
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipePreparationController : Controller
    {
        private readonly IMediator _mediator;

        public RecipePreparationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKitchenTask([FromBody] CreateRecipePreparationCommand command)
        {
            try
            {
                //SentrySdk.CaptureMessage("Request executed successfully.");
                var id = await _mediator.Send(command);
                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            {
                //SentrySdk.CaptureMessage("Request executed successfully.");
                var result = await _mediator.Send(new GetRecipePreparationQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
