using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Contracts
{
    public static class ApiRoutes
    {
        public static class Account
        {
            public const string Base = "account";

            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }

    }
}
