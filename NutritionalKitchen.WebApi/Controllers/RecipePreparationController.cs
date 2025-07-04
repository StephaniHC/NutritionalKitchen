using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Application.RecipePreparation.GetRecipe;
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
        public async Task<ActionResult> CreateRecipePreparation([FromBody] CreateRecipePreparationCommand command)
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
        public async Task<ActionResult> GetRecipePreparation()
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

        [HttpGet]
        public async Task<ActionResult> GetRecipe()
        {
            try
            {
                var result = await _mediator.Send(new GetRecipeQuery(""));
                SentrySdk.CaptureMessage($"[RecipePreparation] Consulta de receta. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/Recipe");
                    scope.Fingerprint = new[] { "recipe_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("today")]
        public async Task<ActionResult> GetTodayRecipePreparation()
        {
            try
            {
                var result = await _mediator.Send(new GetRecipePreparationByTodayQuery());
                SentrySdk.CaptureMessage($"[RecipePreparation] Consulta de recetas del día. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/RecipePreparation/today");
                    scope.Fingerprint = new[] { "recipepreparation_today_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
