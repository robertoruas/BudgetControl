using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _service;

        public IncomeController(IIncomeService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var incomes = await _service.GetAll();

                if (incomes == null) return NotFound();

                return Ok(incomes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get([FromQuery]string description)
        {
            try
            {
                var incomes = await _service.GetAll();

                if (incomes == null) return NotFound();

                return Ok(incomes);

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
                var income = await _service.GetById(id);

                if(income == null) return NotFound(id);

                return Ok(income);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Authorize, Route("{month}/{year}")]
        public async Task<IActionResult> Get(int month, int year)
        {
            try
            {

                var incomes = await _service.GetByMonthAndYear(month, year);
                if (incomes == null) return NotFound($"No incomes found in month {month} and year {year}.");

                return Ok(incomes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                await _service.Add(incomeDTO);
                return Ok(incomeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize,Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                if (id != incomeDTO.Id)
                    throw new ArgumentException($"Param {nameof(id)} not equals in {nameof(incomeDTO)}.{nameof(incomeDTO.Id)}");

                await _service.Update(incomeDTO);

                return Ok(incomeDTO);

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
                var income = await _service.GetById(id);

                if (income == null) return NotFound(id);

                await _service.Delete(income);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
