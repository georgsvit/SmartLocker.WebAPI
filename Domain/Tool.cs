using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Domain.Constants;
using System;

namespace SmartLocker.WebAPI.Domain
{
    public class Tool
    {
        private Tool() { }

        public Tool(ToolCreateRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Description = request.Description;
            ImgUri = request.ImgUrl;
            AccessLevel = (AccessLevel)request.AccessLevel;
            ServiceBook = new ServiceBook(Id, request.LastServiceDate, request.MsBetweenServices, request.MaxUsages, request.Usages);
            ServiceBookId = Id;
        }

        public Tool(ToolEditRequest request)
        {
            Name = request.Name;
            Description = request.Description;
            ImgUri = request.ImgUrl;
            AccessLevel = (AccessLevel)request.AccessLevel;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUri { get; set; }
        public AccessLevel AccessLevel { get; set; }

        public Guid? UserId { get; set; }
        public Guid? LockerId { get; set; }
        public Guid ServiceBookId { get; set; }

        //
        public Locker Locker { get; set; }
        public User User { get; set; }
        public ServiceBook ServiceBook { get; set; }
    }
}
