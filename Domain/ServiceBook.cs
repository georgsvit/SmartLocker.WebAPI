using System;

namespace SmartLocker.WebAPI.Domain
{
    public class ServiceBook
    {
        private ServiceBook() { }

        public ServiceBook(Guid id, DateTime lastServiceDate, TimeSpan timeBetweenServices, int maxUsages, int usages)
        {
            Id = id;
            LastServiceDate = lastServiceDate;
            TimeBetweenServices = timeBetweenServices;
            MaxUsages = maxUsages;
            Usages = usages;
            ToolId = Id;
        }

        public Guid Id { get; set; }
        public DateTime LastServiceDate { get; set; }
        public TimeSpan TimeBetweenServices { get; set; }
        public int MaxUsages { get; set; }
        public int Usages { get; set; }
        public Guid ToolId { get; set; }
    }
}
