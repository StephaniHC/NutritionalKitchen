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
                var result = await _mediator.Send(new GetKitchenTaskQuery(""));
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
