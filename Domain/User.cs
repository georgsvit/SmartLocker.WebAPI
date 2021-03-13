using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain
{
    public class User
    {
        private User() { }

        public User(string firstName, string lastName, string role, AccessLevel accessLevel, string login, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            AccessLevel = accessLevel;
            Login = login;
            Password = password;
        }

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
