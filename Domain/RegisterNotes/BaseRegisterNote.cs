using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class BaseRegisterNote
    {
        protected BaseRegisterNote() { }

        public BaseRegisterNote(DateTime date, Guid userId)
        {
            Date = date;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
