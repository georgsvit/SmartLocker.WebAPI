using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLocker.WebAPI.Contracts;
using SmartLocker.WebAPI.Domain.Constants;
using SmartLocker.WebAPI.Services;
using System;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
    public class DataController : ControllerBase
    {
        private readonly DataService dataService;

        public DataController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost(ApiRoutes.Data.Import)]
        public async Task<IActionResult> ImportData([FromForm] IFormFile file)
        {

            try
            {
                byte[] fileContentBytes = await ReadFileContentBytes(file);
                await dataService.ImportAsync(fileContentBytes);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Data.Export)]
        public async Task<IActionResult> ExportData()
        {
            try
            {
                byte[] fileContent = await dataService.ExportAsync();
                return File(fileContent, "text/plain");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.Data.Backup)]
        public async Task<IActionResult> CreateBackupDb()
        {
            try
            {
                byte[] fileContent = await dataService.CreateBackupAsync();
                return File(fileContent, "application/bak");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task<byte[]> ReadFileContentBytes(IFormFile importDataRequest)
        {
            byte[] fileContentBytes;
            using (var readStream = importDataRequest.OpenReadStream())
            {
                fileContentBytes = new byte[readStream.Length];
                await readStream.ReadAsync(fileContentBytes, 0, (int)readStream.Length);
            }

            return fileContentBytes;
        }
    }
}
