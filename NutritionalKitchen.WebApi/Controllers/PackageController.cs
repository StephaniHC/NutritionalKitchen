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
                var result = await _mediator.Send(new GetPackageQuery(""));
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
