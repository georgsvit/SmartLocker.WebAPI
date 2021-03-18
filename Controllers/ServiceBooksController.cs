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
    public class ServiceBooksController : ControllerBase
    {
        private readonly ServiceBookService bookService;

        public ServiceBooksController(ServiceBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet(ApiRoutes.ServiceBook.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var serviceBooks = await bookService.GetAllAsync();
                return Ok(serviceBooks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(ApiRoutes.ServiceBook.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            try
            {
                ServiceBook book = await bookService.GetOneAsync(id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch(ApiRoutes.ServiceBook.Edit)]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] ServiceBookEditRequest request)
        {
            try
            {
                ServiceBook book = await bookService.EditAsync(id, request);
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
