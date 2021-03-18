using System;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class ServiceRegisterNote : BaseRegisterNote
    {
        private ServiceRegisterNote() { }

        public ServiceRegisterNote(DateTime date, Guid userId, Guid toolId, double cost) : base(date, userId)
        {
            ToolId = toolId;
            Cost = cost;
        }

        public Guid ToolId { get; set; }
        public double Cost { get; set; }

        //
        public Tool Tool { get; set; }
    }
}
