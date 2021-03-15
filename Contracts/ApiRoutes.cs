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

        public static class User
        {
            public const string Base = "user";

            public const string GetAll = Base;
            public const string GetOne = Base + "/{Id}";
            public const string Edit = Base + "/{Id}";
        }

        public static class Data
        {
            public const string Base = "data";

            public const string Export = Base;
            public const string Import = Base;
        }
    }
}
