using System;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class ViolationRegisterNote : BaseRegisterNote
    {
        private ViolationRegisterNote() { }

        public ViolationRegisterNote(DateTime date, Guid userId, Guid lockerId, Guid toolId) : base(date, userId)
        {
            LockerId = lockerId;
            ToolId = toolId;
        }

        public Guid LockerId { get; set; }
        public Guid ToolId { get; set; }

        //
        public Locker Locker { get; set; }
        public Tool Tool { get; set; }
    }
}
