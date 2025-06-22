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
                var result = await _mediator.Send(new GetPreparedFoodQuery(""));
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
