using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.Internal
{
    public record UserIdentity
    {
        public Guid Id { get; }
        public string Login { get; }
        public string Password { get; }
        public string Role { get; }

        public UserIdentity(Guid id, string login, string password, string role) =>
            (Id, Login, Password, Role) = (id, login, password, role);
    }
}
