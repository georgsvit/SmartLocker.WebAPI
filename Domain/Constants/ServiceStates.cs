using System;
using System.Linq;

namespace SmartLocker.WebAPI.Domain.Constants
{
    public static class ServiceStates
    {
        public const string SERVICE_REQUIRED = "SERVICE_REQUIRED";
        public const string IN_SERVICE = "IN_SERVICE";
        public const string SERVICE_REQUESTED = "SERVICE_REQUESTED";
        public const string SERVED = "SERVED";

        public static string[] GetAllRoles() => new string[]
        {
            SERVED,
            SERVICE_REQUIRED,
            SERVICE_REQUESTED,
            IN_SERVICE            
        };

        public static bool IsStateValid(string state) =>
            GetAllRoles().Contains(state.ToUpper());
    }
}
