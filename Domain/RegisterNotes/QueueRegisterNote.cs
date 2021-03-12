using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class QueueRegisterNote : BaseRegisterNote
    {
        private QueueRegisterNote() { }

        public QueueRegisterNote(DateTime date, Guid userId, Guid toolId) : base(date, userId)
        {
            ToolId = toolId;
        }

        public Guid ToolId { get; set; }

        //
        public Tool Tool { get; set; }
    }
}
