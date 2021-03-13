using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record LoginRequest
    {
        public string Login { get; }
        public string Password { get; }
    }
}
