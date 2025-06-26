using MediatR;
using Microsoft.AspNetCore.Mvc; 
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Application.Package.GetPackage;

namespace NutritionalKitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : Controller
    {
        private readonly IMediator _mediator;

        public PackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateKitchenTask([FromBody] CreatePackageCommand command)
        {
            try
            { 
                var id = await _mediator.Send(command); 
                SentrySdk.CaptureMessage($"[Package] Paquete creado exitosamente. ID: {id}", SentryLevel.Info); 

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "POST /api/Package");
                    scope.SetExtra("command", command);
                    scope.Fingerprint = new[] { "package_create", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetKitchenTask()
        {
            try
            { 
                var result = await _mediator.Send(new GetPackageQuery(""));
                SentrySdk.CaptureMessage($"[Package] Consulta de paquetes realizada. Total: {result.Count()}", SentryLevel.Info);

                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex, scope =>
                {
                    scope.SetTag("endpoint", "GET /api/Package");
                    scope.Fingerprint = new[] { "package_get", ex.GetType().ToString() };
                });
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
