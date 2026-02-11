using Application.Commands;
using Application.Queries.Manufacturer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IMediator _mediator;

        public ManufacturerController(ILogger<ManufacturerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateManufacturerCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _mediator.Send(new GetAllManufacturersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }
    }
}
