using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain
{
    public class Locker
    {
        private Locker() { }

        public Locker(string login, string password)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = password;
            IsFull = false;
            IsBlocked = false;
        }

        public Locker(string login, string password, bool isFull, bool isBlocked)
        {
            IsFull = isFull;
            IsBlocked = isBlocked;
            Login = login;
            Password = password;
        }

        public Guid Id { get; set; }
        public bool IsFull { get; set; }
        public bool IsBlocked { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        //
        public List<Tool> Tools { get; set; }

        public LockerDataResponse GetLockerDataResponse() =>
            new(Id, IsFull, IsBlocked, Login, Tools);
    }
}
