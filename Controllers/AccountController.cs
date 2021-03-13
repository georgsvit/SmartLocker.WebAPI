using Microsoft.AspNetCore.Mvc;
using SmartLocker.WebAPI.Contracts;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using SmartLocker.WebAPI.Domain;
using SmartLocker.WebAPI.Domain.Constants;
using SmartLocker.WebAPI.Services;
using System;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost(ApiRoutes.Account.Login)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await accountService.LoginAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }

        [HttpPost(ApiRoutes.Account.Register)]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest registrationRequest)
        {
            string role = Roles.EMPLOYEE;
            try
            {
                if (Roles.IsRoleValid(registrationRequest.Role))
                    role = registrationRequest.Role;
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }            
            
            User user = new(registrationRequest.FirstName, registrationRequest.LastName,
                            role, (AccessLevel)registrationRequest.AccessLevel,
                            registrationRequest.Login, registrationRequest.Password);

            try
            {
                await accountService.RegisterAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse(e.Message));
            }
        }
    }
}
