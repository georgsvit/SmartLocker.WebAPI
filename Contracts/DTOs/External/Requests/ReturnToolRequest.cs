using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ReturnToolRequest(
        [Required] Guid userId,
        [Required] Guid toolId,
        [Required] Guid lockerId,
        [Required] DateTime date
    );
}
