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
    public class LockersController : ControllerBase
    {
        private readonly LockerService lockerService;

        public LockersController(LockerService lockerService)
        {
            this.lockerService = lockerService;
        }

        [HttpGet(ApiRoutes.Locker.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lockers = await lockerService.GetAllAsync();
                return Ok(lockers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Locker.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            try
            {
                Locker locker = await lockerService.GetOneAsync(id);
                return Ok(locker.GetLockerDataResponse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Locker.Create)]
        public async Task<IActionResult> Create([FromBody] LockerCreateRequest request)
        {
            try
            {
                await lockerService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete(ApiRoutes.Locker.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await lockerService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(ApiRoutes.Locker.Edit)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] LockerEditRequest request)
        {
            try
            {
                Locker locker = await lockerService.EditAsync(id, request);
                return Ok(locker.GetLockerDataResponse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Locker.Block)]
        public async Task<IActionResult> Block([FromRoute] Guid id)
        {
            try
            {
                await lockerService.BlockAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Locker.Unblock)]
        public async Task<IActionResult> Unblock([FromRoute] Guid id)
        {
            try
            {
                await lockerService.UnblockAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
