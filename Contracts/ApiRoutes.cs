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
            public const string Backup = Base + "/backup";
        }

        public static class Locker
        {
            public const string Base = "locker";

            public const string GetAll = Base;
            public const string GetOne = Base + "/{Id}";
            public const string Edit = Base + "/{Id}";
            public const string Create = Base;
            public const string Delete = Base + "/{Id}";
            public const string Block = Base + "/block/{Id}";
            public const string Unblock = Base + "/unblock/{Id}";
        }

        public static class ServiceBook
        {
            public const string Base = "servicebook";

            public const string GetAll = Base;
            public const string GetOne = Base + "/{Id}";
            public const string Edit = Base + "/{Id}";
        }

        public static class Tool
        {
            public const string Base = "tool";

            public const string GetAll = Base;
            public const string GetOne = Base + "/{Id}";
            public const string Edit = Base + "/{Id}";
            public const string Create = Base;
            public const string Delete = Base + "/{Id}";
        }

        public static class Accounting
        {
            public const string Base = "accounting";

            public const string ViolationNote = Base + "/violation";
            public const string ServiceNote = Base + "/service";
            public const string AccountingNote = Base;
            
            public const string BookTool = Base + "/queue";
            public const string EnterQueue = Base + "/queue";
        }
    }
}
