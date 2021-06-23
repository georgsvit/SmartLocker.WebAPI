using System;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class QueueRegisterNote : BaseRegisterNote
    {
        private QueueRegisterNote() { }

        public QueueRegisterNote(DateTime date, Guid userId, Guid toolId) : base(date, userId)
        {
            ToolId = toolId;
            UserTurn = false;
        }

        public Guid ToolId { get; set; }
        public bool UserTurn { get; set; }
        //
        public Tool Tool { get; set; }
    }
}