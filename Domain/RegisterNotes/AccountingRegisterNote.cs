using System;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class AccountingRegisterNote : BaseRegisterNote
    {
        private AccountingRegisterNote() { }

        public AccountingRegisterNote(DateTime date, Guid userId, Guid toolId, DateTime? returnDate) : base(date, userId)
        {
            ToolId = toolId;
            ReturnDate = returnDate;          
        }

        public Guid ToolId { get; set; }
        public DateTime? ReturnDate { get; set; }

        //
        public Tool Tool { get; set; }
    }
}
