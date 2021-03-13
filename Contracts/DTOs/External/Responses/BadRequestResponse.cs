using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Responses
{
    public record BadRequestResponse
    {
        public BadRequestResponse(string message) => 
            (Message) = (message);

        public string Message { get; }
    }
}
