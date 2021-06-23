using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLocker.WebAPI.Contracts;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Controllers
{
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly AccountingService accountingService;

        public MaintenanceController(AccountingService accountingService)
        {
            this.accountingService = accountingService;
        }

        [HttpPost(ApiRoutes.Service.Base)]
        public async Task<IActionResult> AddServiceNote([FromBody] ServiceNoteCreateRequest request)
        {
            try
            {
                await accountingService.AddServiceNote(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Service.Base)]
        public async Task<IActionResult> GetServiceRegister([FromBody] ServiceNoteGetRequest request)
        {
            try
            {
                var notes = await accountingService.GetServiceRegister(request);
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Service.GetAvailableServiceTasks)]
        public async Task<IActionResult> GetAvailableServiceTasks()
        {
            try
            {
                var notes = await accountingService.GetAvailableServiceTasks();
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost(ApiRoutes.Service.ApplyServiceNote)]
        public async Task<IActionResult> ApplyServiceNote([FromForm] Guid userId, [FromForm] Guid noteId)
        {
            try
            {
                await accountingService.ApplyServiceNote(userId, noteId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Service.AcceptMaintenance)]
        public async Task<IActionResult> AcceptMaintenance([FromBody] MaintenanceAcceptRequest request)
        {
            try
            {
                await accountingService.AcceptMaintenance(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
