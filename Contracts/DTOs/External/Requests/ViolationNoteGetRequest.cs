using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Requests
{
    public record ViolationNoteGetRequest(
        DateTime StartDate,
        DateTime FinishDate
        );
}
