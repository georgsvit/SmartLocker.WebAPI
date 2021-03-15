using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLocker.WebAPI.Contracts;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
using SmartLocker.WebAPI.Services;
using System;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(ApiRoutes.User.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] string role)
        {
            try
            {
                var users = await userService.GetAllAsync(role);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.User.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            try
            {
                User user = await userService.GetOneAsync(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(ApiRoutes.User.Edit)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] UserEditRequest request)
        {
            try
            {
                User user = await userService.EditAsync(id, request);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
