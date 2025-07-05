using MediatR;
using Microsoft.AspNetCore.Mvc;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Application.Label.GetLabel;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : Controller
    {
        private readonly IMediator _mediator;

        public LabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKitchenTask([FromBody] CreateLabelCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                SentrySdk.CaptureMessage($"[Label] Etiqueta creada exitosamente. ID: {id}", SentryLevel.Info);

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "POST /api/Label");
                    scope.SetExtra("command", command);
                    scope.Fingerprint = new[] { "label_create", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            {
                var result = await _mediator.Send(new GetLabelQuery(""));
                SentrySdk.CaptureMessage($"[Label] Consulta de etiquetas realizada. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/Label");
                    scope.Fingerprint = new[] { "label_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("today/{patientId:guid}")]
        public async Task<ActionResult> GetTodayLabels(Guid patientId)
        {
            try
            {
                var result = await _mediator.Send(new GetLabelByTodayQuery(patientId));
                SentrySdk.CaptureMessage($"[Label] Consulta de etiquetas del día. Paciente: {patientId}. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/Label/today/{patientId}");
                    scope.SetExtra("patientId", patientId);
                    scope.Fingerprint = new[] { "label_today_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
