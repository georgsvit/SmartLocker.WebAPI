using System;
using System.Text.Json.Serialization;

namespace SmartLocker.WebAPI.Domain
{
    public class ServiceBook
    {
        private ServiceBook() { }

        public ServiceBook(Guid id, DateTime lastServiceDate, long msBetweenServices, int maxUsages, int usages)
        {
            Id = id;
            LastServiceDate = lastServiceDate;
            MsBetweenServices = msBetweenServices;
            MaxUsages = maxUsages;
            Usages = usages;
            ToolId = Id;
        }

        public Guid Id { get; set; }
        public DateTime LastServiceDate { get; set; }
        public long MsBetweenServices { get; set; }
        public int MaxUsages { get; set; }
        public int Usages { get; set; }
        public Guid ToolId { get; set; }

        // 
        [JsonIgnore]
        public Tool Tool { get; set; }
    }
}
