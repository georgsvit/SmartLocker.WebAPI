using SmartLocker.WebAPI.Domain.Constants;
using System;

namespace SmartLocker.WebAPI.Domain
{
    public class Tool
    {
        private Tool() { }

        public Tool(string name, string description, string imgUri, AccessLevel accessLevel,
                    DateTime lastServiceDate, TimeSpan serviceInterval,
                    int maxUsages, int usages)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ImgUri = imgUri;
            AccessLevel = accessLevel;
            ServiceBook = new ServiceBook(Id, lastServiceDate, serviceInterval, maxUsages, usages);
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
