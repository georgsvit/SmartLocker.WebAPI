using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record QueueRegisterRequest(
        [Required] Guid UserId,
        [Required] Guid toolId
        );
}
