using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class AccountingRegisterNote : BaseRegisterNote
    {
        private AccountingRegisterNote() { }

        public AccountingRegisterNote(DateTime date, Guid userId, Guid toolId, bool isTaken) : base(date, userId)
        {
            ToolId = toolId;
            IsTaken = isTaken;
        }

        public Guid ToolId { get; set; }
        public bool IsTaken { get; set; }

        //
        public Tool Tool { get; set; }
    }
}
