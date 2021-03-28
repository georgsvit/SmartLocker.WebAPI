using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartLocker.WebAPI.Domain
{
    public class Locker
    {
        private Locker() { }

        [JsonConstructor]
        public Locker(Guid id, bool isFull, bool isBlocked, string login, string password, List<Tool> tools)
        {
            Id = id;
            IsFull = isFull;
            IsBlocked = isBlocked;
            Login = login;
            Password = password;
            Tools = tools;
        }

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
