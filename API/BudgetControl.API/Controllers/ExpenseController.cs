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
                var expenses = await _service.GetAll();

                if (expenses == null) return NotFound();

                return Ok(expenses);

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
                var expense = await _service.GetById(id);

                if (expense == null) return NotFound(id);

                return Ok(expense);
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

                var expenses = await _service.GetByMonthAndYear(month, year);
                if (expenses == null) return NotFound($"No expenses found in month {month} and year {year}.");

                return Ok(expenses);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                await _service.Add(expenseDTO);
                return Ok(expenseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize,Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                if (id != expenseDTO.Id)
                    throw new ArgumentException($"Param {nameof(id)} not equals in {nameof(expenseDTO)}.{nameof(expenseDTO.Id)}");

                await _service.Update(expenseDTO);

                return Ok(expenseDTO);

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
                var expense = await _service.GetById(id);

                if (expense == null) return NotFound(id);

                await _service.Delete(expense);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
