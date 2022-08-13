using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
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

        [HttpGet, Authorize, Route("{id}")]
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

        [HttpGet, Authorize,Route("{month}/{year}")]
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
        public async Task<IActionResult> Post([FromBody] ExpenseDTO outgoingDTO)
        {
            try
            {
                await _service.Add(outgoingDTO);
                return Ok(outgoingDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize,Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExpenseDTO outgoingDTO)
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
