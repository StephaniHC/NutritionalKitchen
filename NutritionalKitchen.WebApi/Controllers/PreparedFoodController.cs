using MediatR;
using Microsoft.AspNetCore.Mvc; 
using NutritionalKitchen.Application.PreparedFood.CreatePreparedFood;
using NutritionalKitchen.Application.PreparedFood.GetPreparedFood;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparedFoodController : Controller
    {
        private readonly IMediator _mediator;

        public PreparedFoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKitchenTask([FromBody] CreatePreparedFoodCommand command)
        {
            try
            { 
                var id = await _mediator.Send(command);
                SentrySdk.CaptureMessage($"[PreparedFood] Comida preparada creada exitosamente. ID: {id}", SentryLevel.Info);

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "POST /api/PreparedFood");
                    scope.SetExtra("command", command);
                    scope.Fingerprint = new[] { "preparedfood_create", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            { 
                var result = await _mediator.Send(new GetPreparedFoodQuery(""));
                SentrySdk.CaptureMessage($"[PreparedFood] Consulta de comidas preparadas realizada. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/PreparedFood");
                    scope.Fingerprint = new[] { "preparedfood_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
