using System.Linq;

namespace SmartLocker.WebAPI.Domain.Constants
{
    public static class Roles
    {
        public const string ADMIN = "ADMIN";
        public const string EMPLOYEE = "EMPLOYEE";
        public const string SERVICEMAN = "SERVICEMAN";

        public static string[] GetAllRoles() => new string[]
        {
            ADMIN,
            EMPLOYEE,
            SERVICEMAN
        };

        public static bool IsRoleValid(string role) =>
            GetAllRoles().Contains(role.ToUpper());
    }
}
