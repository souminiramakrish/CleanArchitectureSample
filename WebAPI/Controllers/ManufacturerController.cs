using Application.Commands;
using Application.Common;
using Application.DTOs;
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
        public async Task<IActionResult> CreateAsync([FromBody] ManufacturerDTO manufacturerDto)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateManufacturerCommand(manufacturerDto)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ManufacturerDTO manufacturerDto)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateManufacturerCommand(manufacturerDto)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteManufacturerCommand(Id)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryFilter filter)
        {
            try
            {
                var result = await _mediator.Send(new GetAllManufacturersQuery(filter));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw;
            }
        }

        [Route("getById/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {
            try
            {
                var result = await _mediator.Send(new GetManufacturerByIdQuery(Id));
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
