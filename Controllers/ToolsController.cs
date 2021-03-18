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
    public class ToolsController : ControllerBase
    {
        private readonly ToolService toolService;

        public ToolsController(ToolService toolService)
        {
            this.toolService = toolService;
        }

        [HttpGet(ApiRoutes.Tool.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tools = await toolService.GetAllAsync();
                return Ok(tools);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Tool.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            try
            {
                Tool tool = await toolService.GetOneAsync(id);
                return Ok(tool);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Tool.Create)]
        public async Task<IActionResult> Create([FromBody] ToolCreateRequest request)
        {
            try
            {
                await toolService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.Tool.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await toolService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(ApiRoutes.Tool.Edit)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] ToolEditRequest request)
        {
            try
            {
                Tool tool = await toolService.EditAsync(id, request);
                return Ok(tool);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
