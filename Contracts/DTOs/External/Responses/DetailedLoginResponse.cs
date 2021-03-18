using System;

namespace SmartLocker.WebAPI.Contracts.DTOs.External.Responses
{
    public record DetailedLoginResponse
    {
        public DetailedLoginResponse(Guid id, string firstName, string lastName, string role, string token, DateTime expireDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Token = token;
            ExpireDate = expireDate;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Role { get; }

        public string Token { get; }
        public DateTime ExpireDate { get; }
    }
}
