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
                var id = await _mediator.Send(command);
                SentrySdk.CaptureMessage($"[RecipePreparation] Preparación de receta creada exitosamente. ID: {id}", SentryLevel.Info);

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "POST /api/RecipePreparation");
                    scope.SetExtra("command", command);
                    scope.Fingerprint = new[] { "recipepreparation_create", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            { 
                var result = await _mediator.Send(new GetRecipePreparationQuery(""));
                SentrySdk.CaptureMessage($"[RecipePreparation] Consulta de preparaciones de receta realizada. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/RecipePreparation");
                    scope.Fingerprint = new[] { "recipepreparation_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
