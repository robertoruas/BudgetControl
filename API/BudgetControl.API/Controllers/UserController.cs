using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAll();

                if (users == null) return NotFound();

                return Ok(users);
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
                var user = await _userService.GetById(id);

                if (user == null) return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost, Authorize, Route("{id}")]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            try
            {
                await _userService.Add(userDTO);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                if (id != userDTO.Id)
                {
                    throw new ArgumentException($"Param {nameof(id)} not equals in {nameof(userDTO)}.{nameof(userDTO.Id)}");
                }

                await _userService.Update(userDTO);
                return Ok(userDTO);
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
                var userDTO = await _userService.GetById(id);
                if (userDTO == null)
                    return NotFound();

                await _userService.Delete(userDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
