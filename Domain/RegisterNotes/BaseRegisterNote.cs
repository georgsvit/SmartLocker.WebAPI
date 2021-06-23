using System;

namespace SmartLocker.WebAPI.Domain.RegisterNotes
{
    public class BaseRegisterNote
    {
        protected BaseRegisterNote() { }

        public BaseRegisterNote(DateTime date, Guid? userId)
        {
            Date = date;
            UserId = userId;
            IsViewed = false;
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid? UserId { get; set; }
        public bool IsViewed { get; set; }

        //
        public User User { get; set; }
    }
}
