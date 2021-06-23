using SmartLocker.WebAPI.Contracts.DTOs.External.Responses;
using SmartLocker.WebAPI.Domain.Constants;
using SmartLocker.WebAPI.Domain.RegisterNotes;
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
        public List<ServiceRegisterNote> ServiceNotes { get; set; }
        public List<ViolationRegisterNote> ViolationNotes { get; set; }
        public List<AccountingRegisterNote> AccountingNotes { get; set; }

        public UserDataResponse GetUserDataResponse()
        {
            if (ServiceNotes is not null)
                ServiceNotes.ForEach(sn => { sn.Tool.SetNull(); sn.User = null; });
            if (ViolationNotes is not null)
                ViolationNotes.ForEach(vn => { vn.Tool.SetNull(); vn.User = null; vn.Locker.Tools = null; });
            if (AccountingNotes is not null)
                AccountingNotes.ForEach(an => { an.User = null; an.Tool.SetNull(); });
                
            return new(Id, FirstName, LastName, Role, AccessLevel, Login, Tools, ServiceNotes, ViolationNotes, AccountingNotes);
        }

        public void RemoveUselessData()
        {
            ServiceNotes = null;
            ViolationNotes = null;
            AccountingNotes = null;
        }
    }
}
