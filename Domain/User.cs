using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain
{
    public class User
    {
        private User() { }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public AccessLevel AccessLevel { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        //
        public List<Tool> Tools { get; set; }
    }
}
