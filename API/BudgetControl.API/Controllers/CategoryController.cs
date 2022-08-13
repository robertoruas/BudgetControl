using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _service.GetAll();

                if (categories == null) return NotFound();

                return Ok(categories);

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
                var category = await _service.GetById(id);

                if (category == null) return NotFound(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await _service.Add(categoryDTO);
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize, Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                if (id != categoryDTO.Id)
                    throw new ArgumentException($"Param {nameof(id)} not equals in {nameof(categoryDTO)}.{nameof(categoryDTO.Id)}");

                await _service.Update(categoryDTO);

                return Ok(categoryDTO);

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
                var category = await _service.GetById(id);

                if (category == null) return NotFound(id);

                await _service.Delete(category);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
