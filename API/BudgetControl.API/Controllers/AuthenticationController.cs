using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Infrastructure.Identity.Authentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers
{
    [ApiController, Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _service;
        private readonly IUserService _userService;

        public AuthenticationController(ITokenService service, IUserService userService)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var mapUser = await _userService.GetUserByUsernameAndPassword(loginDTO.UserName, loginDTO.Password);

                if (mapUser == null) return NotFound(new { message = "username or password wrong." });

                string token = _service.GenerateToken(mapUser);

                return Ok(new
                {
                    token,
                    user = new UserDTO
                    {
                        Id = mapUser.Id,
                        Name = mapUser.Name,
                        Email = mapUser.Email,
                        UserName = mapUser.UserName,
                        Status = mapUser.Status
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
