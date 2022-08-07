using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class OutgoingController : ControllerBase
    {
        private readonly IOutgoingService _service;

        public OutgoingController(IOutgoingService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outgoings = await _service.GetAll();

                if (outgoings == null) return NotFound();

                return Ok(outgoings);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var outgoing = await _service.GetById(id);

                if (outgoing == null) return NotFound(id);

                return Ok(outgoing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get(int month, int year)
        {
            try
            {

                var outgoings = await _service.GetByMonthAndYear(month, year);
                if (outgoings == null) return NotFound($"No outgoings found in month {month} and year {year}.");

                return Ok(outgoings);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] OutgoingDTO outgoingDTO)
        {
            try
            {
                await _service.Add(outgoingDTO);
                return new CreatedAtRouteResult("Get", new OutgoingDTO { Id = outgoingDTO.Id }, outgoingDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] OutgoingDTO outgoingDTO)
        {
            try
            {
                if (id != outgoingDTO.Id)
                    throw new ArgumentException($"Param {nameof(id)} not equals in {nameof(outgoingDTO)}.{nameof(outgoingDTO.Id)}");

                await _service.Update(outgoingDTO);

                return Ok(outgoingDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var outgoing = await _service.GetById(id);

                if (outgoing == null) return NotFound(id);

                await _service.Delete(outgoing);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
