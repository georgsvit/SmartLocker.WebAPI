using System;
using System.Collections.Generic;

namespace SmartLocker.WebAPI.Domain
{
    public class Locker
    {
        private Locker() { }

        public Guid Id { get; set; }
        public bool IsFull { get; set; }
        public bool IsBlocked { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        //
        public List<Tool> Tools { get; set; }
    }
}
