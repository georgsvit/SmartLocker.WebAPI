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
        private readonly ReportService reportService;

        public AccountingController(AccountingService accountingService, ReportService reportService)
        {
            this.accountingService = accountingService;
            this.reportService = reportService;
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
        public async Task<IActionResult> ReturnTool([FromBody] ReturnToolRequest request)
        {
            try
            {
                await accountingService.ReturnTool(request.userId, request.toolId, request.lockerId, request.date);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Accounting.TakeTool)]
        public async Task<IActionResult> TakeTool([FromBody] TakeToolRequest request)
        {
            try
            {
                await accountingService.TakeTool(request.userId, request.toolId, request.date);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.Notification)]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var notes = await accountingService.GetNotifications();
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.GetWorkerNotifications)]
        public async Task<IActionResult> GetWorkerNotifications([FromRoute] Guid id)
        {
            try
            {
                var notes = await accountingService.GetWorkerNotifications(id);
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.SetNotificationViewed)]
        public async Task<IActionResult> SetNotificationViewed([FromRoute] Guid id)
        {
            try
            {
                await accountingService.SetNotificationViewed(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.ServiceRegisterReports)]
        public async Task<IActionResult> GetServiceRegisterReport()
        {
            try
            {
                var notes = await accountingService.ServiceRegisterNotes();
                var response = reportService.GetServiceRegisterReport(notes);

                return File(response, "text/plain", $"Service Register: {DateTime.Now}.txt");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.ViolationRegisterReports)]
        public async Task<IActionResult> GetViolationRegisterReport()
        {
            try
            {
                var notes = await accountingService.ViolationRegisterNotes();
                var response = reportService.GetViolationRegisterReport(notes);

                return File(response, "text/plain", $"Violation Register: {DateTime.Now}.txt");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Accounting.AccountingRegisterReports)]
        public async Task<IActionResult> GetAccountingRegisterReport()
        {
            try
            {
                var notes = await accountingService.AccountingRegisterNotes();
                var response = reportService.GetAccountingRegisterReport(notes);

                return File(response, "text/plain", $"Accounting Register: {DateTime.Now}.txt");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(ApiRoutes.Accounting.EnterQueue)]
        public ActionResult EnterQueue([FromBody] QueueRegisterRequest request)
        {
            try
            {
                var result = accountingService.EnterQueue(request.UserId, request.toolId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Locker.GetConfig)]
        public ActionResult LockerGetConfig([FromRoute] Guid id)
        {
            try
            {
                var result = accountingService.GetLockersConfig(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
