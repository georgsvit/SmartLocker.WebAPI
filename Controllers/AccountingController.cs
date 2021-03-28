using Microsoft.AspNetCore.Mvc;
using SmartLocker.WebAPI.Contracts;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Services;
using System;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Controllers
{
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly AccountingService accountingService;

        public AccountingController(AccountingService accountingService)
        {
            this.accountingService = accountingService;
        }

        [HttpPost(ApiRoutes.Accounting.ViolationNote)]
        public async Task<IActionResult> AddViolationNote([FromBody] ViolationNoteCreateRequest request)
        {
            try
            {
                await accountingService.AddViolationNote(request);
                return Ok();
            }
            catch (Exception e)
            {   
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.ViolationNote)]
        public async Task<IActionResult> GetViolationNote([FromBody] ViolationNoteGetRequest request)
        {
            try
            {
                var notes = await accountingService.GetViolationRegister(request);
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Accounting.ReturnTool)]
        public async Task<IActionResult> ReturnTool([FromForm] Guid userId, [FromForm] Guid toolId, [FromForm] Guid lockerId)
        {
            try
            {
                await accountingService.ReturnTool(userId, toolId, lockerId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Accounting.TakeTool)]
        public async Task<IActionResult> TakeTool([FromForm] Guid userId, [FromForm] Guid toolId)
        {
            try
            {
                await accountingService.TakeTool(userId, toolId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
