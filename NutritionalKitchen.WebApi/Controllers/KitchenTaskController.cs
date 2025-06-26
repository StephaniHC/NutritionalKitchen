using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.Application.KitchenTask.CreateKitchenTask;
using NutritionalKitchen.Application.KitchenTask.GetKitchenTask; 

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenTaskController : Controller
    {
        private readonly IMediator _mediator; 
        public KitchenTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreateKitchenTask([FromBody] CreateKitchenTaskCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                SentrySdk.CaptureMessage($"[KitchenTask] Tarea de cocina creada exitosamente. ID: {id}", SentryLevel.Info);

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "POST /api/KitchenTask");
                    scope.SetExtra("command", command);
                    scope.Fingerprint = new[] { "kitchen_task_create", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            {
                var result = await _mediator.Send(new GetKitchenTaskQuery(""));
                SentrySdk.CaptureMessage($"[KitchenTask] Consulta de tareas realizada. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/KitchenTask");
                    scope.Fingerprint = new[] { "kitchen_task_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
